using MongoDB.Driver;
using MongoDB.Bson;

internal class MongoDAO : IProductDAO
{
	MongoClient dbClient;	//nieważne teraz
	IMongoDatabase database;

	public MongoDAO(string connectionString, string database)
	{
		this.dbClient = new MongoClient(connectionString); 
		this.database = this.dbClient.GetDatabase(database);
	}

	public void CreateProduct()
	{
		throw new NotImplementedException();
	}

	public void DeleteProduct()
	{
		throw new NotImplementedException();
	}

	public List<string> GetAllProducts()
	{
		throw new NotImplementedException();
	}

	public void UpdateProduct()
	{
		throw new NotImplementedException();
	}
}

