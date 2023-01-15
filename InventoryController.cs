
internal class InventoryController
{
	IStringIO io;
	IProductDAO productDAO;
	public InventoryController(IStringIO io, IProductDAO productDAO)
	{
		this.io = io;
		this.productDAO = productDAO;
	}

	public void Start()
	{
		//loop
		productDAO.GetAllProducts().ForEach(product => { io.PrintString(product); });

		string title;
		string description;
		int amount;
		//lägga till
		productDAO.CreateProduct();
	}
	private int GameMenu()  //główne menu
	{
		io.PrintString("Vad vill du göra nu?");
		int answer;
			bool success = int.TryParse(io.GetString(), out answer);
		return answer;
	}
}
