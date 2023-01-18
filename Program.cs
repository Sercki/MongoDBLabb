global using MongoDB.Driver;
global using MongoDB.Bson;

IStringIO io; // min UI
IEquipmentDAO itemDAO; //  min database 
string connectionString = ConnectionString.ConnectionStr;

io = new TraditionalTextIO();   //implementation av IO/UI
itemDAO = new MongoDAO(connectionString, "MongoDBLabb", "Sport Equipment");	// DAO

InventoryController controller = new InventoryController(io, itemDAO);//hanterar inventory med massa produkter (kopplar allting)
controller.Start();                                                     //starta programmet