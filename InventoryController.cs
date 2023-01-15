
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
		itemDAO.GetAllItems().ForEach(product => { io.PrintString(product); });

		string title;
		string description;
		int amount;
		//lägga till
		itemDAO.CreateItem();
	}
	private int GameMenu()  //główne menu
	{
		io.PrintString("Vad vill du göra nu?");
		int answer;
			bool success = int.TryParse(io.GetString(), out answer);
		return answer;
	}
}
