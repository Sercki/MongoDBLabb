global using MongoDB.Driver;
global using MongoDB.Bson;
using System.IO;


IStringIO io; //albo IUI (interface UI) interface för string input output- min UI
IEquipmentDAO itemDAO; // database access object - min database 
string connectionString = ConnectionString.ConnectionStr;

io = new TraditionalTextIO();   //välj en implementation av IO/UI
itemDAO = new MongoDAO(connectionString, "MongoDBLabb", "Sport Equipment");	//välj en implementation av DAO

InventoryController controller = new InventoryController(io, itemDAO);//hanterar inventory med massa produkter  (koppla allting)
controller.Start();                                                     //starta programmet

//
//DataBaseControllers CRUD = new();
//bool menu = true;
//while (menu)
//{
//	Console.WriteLine("==== Sport's equipment library ====\nActive User:ADMIN\n\n1. Register a donated item(Add a new product)\n2. Show all items.\n3. Find a specific equipment.\n4. Change status of equipment(available or borrowed)." +
//		"\n5. Erase item from database.\n6. Exit program.\nPlease select one of the alternatives:");
//	Console.Write(">");
//	int input = CRUD.CheckNumberInput();
//	switch (input)
//	{//readall tez ma byc
//		case 1:
//			CRUD.AddProduct(collection);
//			break;
//		case 2:
//			CRUD.ShowAll(collection);
//			break;
//		case 3:
//			CRUD.FindProduct(collection);
//			break;
//		case 4:
//			CRUD.LendOrReturnequipment(collection);
//			break;
//		case 5:
//			CRUD.DeleteEquipment(collection);
//			break;
//		case 6:
//			menu = false;
//			Console.WriteLine("Shutting down!");
//			break;

//		default:
//			Console.WriteLine("Wrong choice! Please select numbers 1-6\n");
//			break;
//	}
//}

//public class DataBaseControllers
//{
//	//en metod för att lägga till en ny produkt i en databas
//	public void AddProduct(IMongoCollection<BsonDocument> dbCollection)
//	{
//		string isAvailable = "yes";                                 //En produkt är automatiskt tillgånglig att låna ut
//		Console.WriteLine("\nPlease carefully follow these instructions to add a new equipment to the database:");
//		Console.WriteLine("Write code of the shelf to easily locate equipment:");
//		string shelfID = CheckLetterInput();
//		Console.WriteLine("Write the name of an item:");
//		string name = CheckLetterInput();
//		Console.WriteLine("Write short description of the product:");
//		string description = CheckLetterInput();
//		var document = new BsonDocument
//		{
//			{"shelf", $"{shelfID}" },			//like index. every equipment has its own shelf id - imagine shelf A with hooks 1,2,3,4 etc..., shelf b with compartments 1,2,3,4 etc... No two equipments on occupy same hook/compartment
//			{"name", $"{name}" },
//			{"description", $"{description}" },
//			{"is available", $"{isAvailable}"  }
//		};
//---------------zostalo uzyte----------------------
//		dbCollection.InsertOne(document);
//---------------zostalo uzyte----------------------
//		Console.WriteLine($"shelf: {shelfID}\nname: {name}\ndescription: {description}\navailable: {isAvailable}");
//		Console.WriteLine("Sport equipment was succesfully added!");
//	}
//	public void ShowAll(IMongoCollection<BsonDocument> dbCollection)
//	{
//---------------zostalo uzyte----------------------
//		var SportEquipment = dbCollection.Find(new BsonDocument()).ToList();
//---------------zostalo uzyte----------------------
//		foreach (var item in SportEquipment)
//		{
//			Console.WriteLine(item);
//		}
//		Console.WriteLine("");
//	}
//	public void FindProduct(IMongoCollection<BsonDocument> dbCollection)    //zmienić by prosić tylko o shelf ID
//	{
//		Console.WriteLine("Please add all necessary info to create a filter. \nFirst write down what kind of information should program use to filter the results?\nChoose one of the following: name, shelf, description, is available.");
//		string filterDefinition = CheckLetterInput();
//		Console.WriteLine("Please write down specific information which fits chosen filter:");
//		string filterValue = CheckLetterInput();
//		var filter = Builders<BsonDocument>.Filter.Eq($"{filterDefinition}", $"{filterValue}");
//		var SportsEquipmentFilter = dbCollection.Find(filter).FirstOrDefault();
//		if (SportsEquipmentFilter != null)
//		{
//			Console.WriteLine(SportsEquipmentFilter.ToString());
//		}
//		else
//		{
//			Console.WriteLine("Sorry, it is impossible to  find any products with provided information!\n");
//		}
//	}	
//	public void LendOrReturnequipment(IMongoCollection<BsonDocument> dbCollection) 
//	{
//		Console.WriteLine("Press \"1\" to lend or \"2\" to register return of an equipment.");
//		int input = 0;
//		string choice = "";
//		string availability = "";
//		while (input < 1 || input > 2)
//		{
//			input = CheckNumberInput();
//			if (input == 1)
//			{
//				choice = "lend";
//				availability = "borrowed";
//			}
//			else if (input == 2) 
//			{
//				choice = "return";
//				availability = "yes";
//			}
//			else
//			{
//				Console.WriteLine("Wrong choice! Try writing \"1\" or \"2\"");
//			}
//		}
//		Console.WriteLine($"Your Choice: {choice}");
//		
//		Console.WriteLine($"Please write equipments location(shelf ID)?");
//		string location = CheckLetterInput();
//---------------zostalo uzyte----------------------
//		var filter = Builders<BsonDocument>.Filter.Eq("shelf", $"{location}");
//		var update = Builders<BsonDocument>.Update.Set("is available", $"{availability}");
//		dbCollection.UpdateOne(filter, update);
//---------------zostalo uzyte----------------------
//	}
//	public void DeleteEquipment(IMongoCollection<BsonDocument> dbCollection)     
//	{
//		Console.WriteLine($"Please write equipments location(shelf ID)?");
//		string location = CheckLetterInput();
//---------------zostalo uzyte----------------------
//		var deleteFilter = Builders<BsonDocument>.Filter.Eq("shelf", $"{location}");
//		dbCollection.DeleteOne(deleteFilter);
//---------------zostalo uzyte----------------------
//	}	
//}
//public class Product
//{
//	public string shelfID { get; set; }
//	public string Name { get; set; }
//	public string Description { get; set; }
//	public string Availability { get; set; }
//}