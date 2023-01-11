using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;

var client = new MongoClient(ConnectionString.ConnectionStr);
var database = client.GetDatabase("MongoDBLabb");
var collection = database.GetCollection<BsonDocument>("Sport Equipment");
DataBaseControllers CRUD = new();
bool menu = true;
while (menu)
{
	Console.WriteLine("==== Sport's equipment library ====\nActive User:ADMIN\n\n1. Register a donated item(Add a new product)\n2. Show all items.\n3. Find a specific equipment.\n4. Lend an equipment(Update a product information)." +
		"\n5. Erase item from database.\n6. Exit program.\nPlease select one of the alternatives:");
	Console.Write(">");
	int input = CRUD.CheckNumberInput();
	switch (input)
	{//readall tez ma byc
		case 1:
			CRUD.AddProduct(collection);
			break;
		case 2:
			CRUD.ShowAll(collection);
			break;
		case 3:
			CRUD.FindProduct(collection);
			break;
		case 4:
			Console.WriteLine(4);
			break;
		case 5:
			Console.WriteLine(5);
			break;
		case 6:
			menu = false;
			Console.WriteLine("Shutting down!");
			break;

		default:
			Console.WriteLine("Wrong choice! Please select numbers 1-6\n");
			break;
	}
}

public class DataBaseControllers
{
	//en metod för att lägga till en ny produkt i en databas
	public void AddProduct(IMongoCollection<BsonDocument> dbCollection)
	{
		string isAvailable = "yes";                                 //En produkt är automatiskt tillgånglig att låna ut
		Console.WriteLine("\nPlease carefully follow these instructions to add a new equipment to the database:");
		Console.WriteLine("Write code of the shelf to easily locate equipment:");
		string shelfID = CheckLetterInput();
		Console.WriteLine("Write the name of an item:");
		string name = CheckLetterInput();
		Console.WriteLine("Write short description of the product:");
		string description = CheckLetterInput();
		var document = new BsonDocument
		{
			{"shelf", $"{shelfID}" },
			{"name", $"{name}" },
			{"description", $"{description}" },
			{"is available", $"{isAvailable}"  }
		};
		dbCollection.InsertOne(document);
		Console.WriteLine($"shelf: {shelfID}\nname: {name}\ndescription: {description}\navailable: {isAvailable}");
		Console.WriteLine("Sport equipment was succesfully added!");
	}
	public void ShowAll(IMongoCollection<BsonDocument> dbCollection)
	{
		var SportEquipment = dbCollection.Find(new BsonDocument()).ToList();
		foreach (var item in SportEquipment)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("");
	}
	public void FindProduct(IMongoCollection<BsonDocument> dbCollection)
	{
		Console.WriteLine("Please add all necessary info to create a filter. \nFirst write down what kind of information should program use to filter the results?");
		string filterDefinition = CheckLetterInput();
		Console.WriteLine("Please write down specific information which fits chosen filter:");
		string filterValue = CheckLetterInput();
		var filter = Builders<BsonDocument>.Filter.Eq($"{filterDefinition}", $"{filterValue}");
		var SportsEquipmentFilter = dbCollection.Find(filter).FirstOrDefault();
		if (SportsEquipmentFilter != null)                              //om man gav felaktig info till filterDefinition eller/och filterValue programmet crashade. Jag löste problemet med if sats (SportsEquipmentFilter !=null) eftersom try-catch
		{                                                               //hjälpte inte - programmet crashade med meddelande att sportsequipmentfilter blir null. 
			Console.WriteLine(SportsEquipmentFilter.ToString());
		}
		else
		{
			Console.WriteLine("Sorry, it is impossible to  find any products with provided information!\n");
		}
	}
	public void UpdateProduct()
	{
		//would you like to (B)orrow or (R)eturn equipment? b/r?
	//is available - yes or borrowed
	}
	public void DeleteProduct()
	{ }
	//en metod för att kolla om användaren skriver minst en tecken
	public string CheckLetterInput()
	{
		bool check = true;
		string textInput = "";
		while (check)
		{
			textInput = Console.ReadLine();
			if (textInput == "")
			{
				Console.WriteLine("Sorry! You wrote nothing here. Please add at least one symbol.Try again!");
			}
			else
			{
				check = false;
			}
		}
		return textInput;
	}
	//en metod fär att kolla om användaren skriver siffror
	public int CheckNumberInput()
	{
		bool checkIfNumberInput = false;
		int value = -1;
		while (checkIfNumberInput == false)
		{
			bool checkInput = int.TryParse(Console.ReadLine(), out value);
			if (checkInput == false)
			{
				Console.WriteLine("Wrong input! Write just numbers please:");
			}
			else
			{
				checkIfNumberInput = true;
			}
		}
		return value;
	}
}
public class Product
{
	public string shelfID { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Availability { get; set; } //bool?
}