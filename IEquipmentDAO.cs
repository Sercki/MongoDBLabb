internal interface IEquipmentDAO
	{
	public List<BsonDocument> GetAllItems();

	public List<BsonDocument> GetAllItemsWithFilter(string filterDefinition, string filterValue);

	public void CreateItem(BsonDocument document);

	public void UpdateItem(string filterDefinition, string filterValue, string setDefinition, string setValue);

	public void DeleteItem(string filterDefinition, string filterValue);
	}

