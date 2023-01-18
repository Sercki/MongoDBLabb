internal class TraditionalTextIO : IStringIO
{
	public void Exit()
	{
		System.Environment.Exit(0);
	}

	public string GetString()
	{                                       //en metod för att kolla om användaren skriver minst en tecken
		bool check = true;
		string textInput = "";
		while (check == true)
		{
			try
			{
				textInput = Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			if (textInput == "")
			{
				try
				{
					Console.WriteLine("Sorry! You wrote nothing here. Please add at least one symbol.Try again!");
				}
				catch (Exception e)
				{
					Console.WriteLine($"Oops! Don't worry, just send this to your programmer: {e}");
				}
			}
			else
			{
				check = false;
			}
		}
		return textInput;
	}
	public void PrintString(string output)      //en metod för att skriva ut text
	{
		try
		{
			Console.WriteLine(output);
		}
		catch (Exception)
		{
			Console.WriteLine("Oops! Something went wrong."); 
		}
	}
}
