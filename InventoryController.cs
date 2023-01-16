
using System.Runtime.CompilerServices;

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
		//loop
		while (true)
		{
			MainMenu();
		}
		//itemDAO.GetAllItems().ForEach(product => { io.PrintString(product); });

		//string title;
		//string description;
		//int amount;
		////lägga till
		//itemDAO.CreateItem();
	}
	private void MainMenu()
	{
		io.PrintString("==== Sport's equipment library ====\nActive User:ADMIN\n\n1. Register a donated item(Add a new product)\n2. Show all items.\n3. Show all items of one type\n4. Change status of equipment(available or borrowed)." +
			"\n5. Erase item from database.\n6. Exit program.\nPlease select one of the alternatives:");
		bool success = int.TryParse(io.GetString(), out int input);                                     //sprawdzic czy nie wywali bledu jak wstawie litere zamiast cyfry w menu
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
					io.Exit();
					io.PrintString("Shutting down!");
					break;
				default:
					io.PrintString("Wrong choice! Please select numbers 1-6\n");
					break;
			}
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
			{"shelf", $"{shelfID}" },			//som index - varje utrustning har sin egen "shelf id" - Tänk om hylla A med krokar 1,2,3,4 etc..., hylla b med hyllfack 1,2,3,4 etc... inga hyllor innehåller mer än en utrustning
			{"name", $"{name}" },
			{"description", $"{description}" },
			{"is available", $"{isAvailable}"  }
		};
		itemDAO.CreateItem(document);
		io.PrintString($"shelf: {shelfID}\nname: {name}\ndescription: {description}\navailable: {isAvailable}\nSport equipment was succesfully added!");
	}
	private void ShowAll()
	{
		itemDAO.GetAllItems().ForEach(item => io.PrintString(item.ToString()));
	}
	private void ShowAllwithfilter()
	{
		io.PrintString("What are you looking for? Please write name of the equipment");
		string equipmentName = io.GetString();
		itemDAO.GetAllItemsWithFilter("name", equipmentName).ForEach(item => io.PrintString(item.ToString()));

	}
	private void LendOrReturnequipment()
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
	}
	private void DeleteEquipment()
	{
		io.PrintString($"Please write equipments location(shelf ID)?");
		string location = io.GetString();
		itemDAO.DeleteItem("shelf", location);	
	}
}
