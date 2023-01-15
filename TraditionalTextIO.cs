
internal class TraditionalTextIO : IStringIO
{
	public void Clear()
	{
		//behövs inte i den här implementation
	}

	public void Exit()
	{
		System.Environment.Exit(0);
	}

	public string GetString()
	{
		return Console.ReadLine();
	}

	public void PrintString(string output)
	{
		Console.WriteLine(output);
	}
}
