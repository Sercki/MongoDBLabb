internal class MongoDAO : IEquipmentDAO					//försökte göra metoder generella, som man kan använda senare i ett annat program/ annan implementation av program
{
	MongoClient dbClient;
	IMongoDatabase database;
	IMongoCollection<BsonDocument> collection;

	public MongoDAO(string connectionString, string database, string collection)
	{
		this.dbClient = new MongoClient(connectionString); 
		this.database = this.dbClient.GetDatabase(database);
		this.collection = this.database.GetCollection<BsonDocument>(collection);
	}

	public void CreateItem(BsonDocument document)
	{
		collection.InsertOne(document);
	}

	public List<BsonDocument> GetAllItems()  //verkar lättare och mer lättläst att ha båda GetAllItems och GetAllItemsWithFilter, än att skapa en metod med båda funktioner
	{		
		return collection.Find(new BsonDocument()).ToList();		
	}

	public List<BsonDocument> GetAllItemsWithFilter(string filterDefinition, string filterValue)
	{
		var GetAllItemsFilter = Builders<BsonDocument>.Filter.Eq(filterDefinition, filterValue);
		return collection.Find(GetAllItemsFilter).ToList();
	}

	public void UpdateItem(string filterDefinition, string filterValue, string setDefinition, string setValue)
	{
	var filter = Builders<BsonDocument>.Filter.Eq(filterDefinition, filterValue);
	var update = Builders<BsonDocument>.Update.Set(setDefinition, setValue);
	collection.UpdateOne(filter, update);
	}

	public void DeleteItem(string filterDefinition, string filterValue)
	{
		var deleteFilter = Builders<BsonDocument>.Filter.Eq(filterDefinition, filterValue);
		collection.DeleteOne(deleteFilter);
	}
}

