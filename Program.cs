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