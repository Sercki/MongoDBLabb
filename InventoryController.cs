internal class InventoryController
{
	IStringIO io;
	IEquipmentDAO itemDAO;
	public InventoryController(IStringIO io, IEquipmentDAO itemDAO)
	{
		this.io = io;
		this.itemDAO = itemDAO;
	}

	public void Start()
	{
		while (true)
		{
			MainMenu();
		}
	}
	private void MainMenu()
	{
		io.PrintString("==== Sport's equipment library ====\nActive User:ADMIN\n\n1. Register a donated item(Add a new product)\n2. Show all items\n3. Show all items of one type\n4. Change status of equipment(available or borrowed)" +
			"\n5. Erase item from database\n6. Exit program\nPlease select one of the alternatives:");
		bool success = int.TryParse(io.GetString(), out int input);                                     
		if (success == true)
		{
			switch (input)
			{
				case 1:
					AddEquipment();
					break;
				case 2:
					ShowAll();
					break;
				case 3:
					ShowAllwithfilter();
					break;
				case 4:
					LendOrReturnequipment();
					break;
				case 5:
					DeleteEquipment();
					break;
				case 6:
					io.PrintString("Shutting down!");
					io.Exit();					
					break;
				default:
					io.PrintString("Wrong choice! Please select numbers 1-6.\n");
					break;
			}
		}
		else
		{
			io.PrintString("Wrong input! Try numbers only!\n");
		}
	}
	private void AddEquipment()         //en metod för att lägga till en ny produkt i en databas
	{
		string isAvailable = "yes";                                 //En produkt är automatiskt tillgånglig att låna ut
		io.PrintString("\nPlease carefully follow these instructions to add a new equipment to the database:\nWrite code of the shelf to easily locate equipment:");
		string shelfID = io.GetString();
		io.PrintString("Write the name of an item:");
		string name = io.GetString();
		io.PrintString("Write short description of the product:");
		string description = io.GetString();
		var document = new BsonDocument
		{
			{"shelf", shelfID },			//som index - varje utrustning har sin egen "shelf id" - Tänk om hylla A med krokar 1,2,3,4 etc..., hylla b med hyllfack 1,2,3,4 etc... inga hyllor innehåller mer än en utrustning
			{"name", name },
			{"description", description },
			{"is available", isAvailable  }
		};
		itemDAO.CreateItem(document);
		io.PrintString($"shelf: {shelfID}\nname: {name}\ndescription: {description}\navailable: {isAvailable}\nSport equipment was succesfully added!\n");
	}
	private void ShowAll()      //en metod för att visa hela sortimentet i "idrottsbibliotek"
	{
		itemDAO.GetAllItems().ForEach(item => io.PrintString(item.ToString()));
	}
	private void ShowAllwithfilter()    //en metod för att visa en del av sortimentet i "idrottsbibliotek"
	{
		io.PrintString("What are you looking for? Please write name of the equipment");
		string equipmentName = io.GetString();
		itemDAO.GetAllItemsWithFilter("name", equipmentName).ForEach(item => io.PrintString(item.ToString()));
	}
	private void LendOrReturnequipment()	//en implementation av update metod (man för endast byta "isAvailable")
	{
		io.PrintString("Press \"1\" to lend or \"2\" to register return of an equipment.");
		int input = 0;
		string choice = "";
		string availability = "";
		while (input < 1 || input > 2)
		{
			int.TryParse(io.GetString(), out input);
			if (input == 1)
			{
				choice = "lend";
				availability = "borrowed";
			}
			else if (input == 2)
			{
				choice = "return";
				availability = "yes";
			}
			else
			{
				io.PrintString("Wrong choice! Try writing \"1\" or \"2\"");
			}
		}
		io.PrintString($"Your Choice: {choice}\nPlease write equipments location(shelf ID)?");
		string location = io.GetString();
		itemDAO.UpdateItem("shelf", location, "is available", availability);
		io.PrintString($"Equipment status succesfully changed!\n");
	}
	private void DeleteEquipment()	//en metod för att radera utrustning från en databas
	{
		io.PrintString($"Please write equipments location(shelf ID)?");
		string location = io.GetString();
		itemDAO.DeleteItem("shelf", location);
		io.PrintString($"Equipment removed from database!\n");
	}
}
