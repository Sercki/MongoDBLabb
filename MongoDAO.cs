using MongoDB.Driver;
using MongoDB.Bson;

internal class MongoDAO : IEquipmentDAO
{
	MongoClient dbClient;
	IMongoDatabase database;

	public MongoDAO(string connectionString, string database)
	{
		this.dbClient = new MongoClient(connectionString); 
		this.database = this.dbClient.GetDatabase(database);
	}

	public void CreateItem()
	{
		throw new NotImplementedException();
	}

	public void DeleteItem()
	{
		throw new NotImplementedException();
	}

	public List<string> GetAllItems()
	{
		throw new NotImplementedException();
	}

	public void UpdateItem()
	{
		throw new NotImplementedException();
	}
}

