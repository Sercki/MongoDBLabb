
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
	{                                       //en metod för att kolla om användaren skriver minst en tecken
		bool check = true;
		string textInput = "";
		while (check)
		{
			textInput = Console.ReadLine();
			if (textInput == "")
			{
				Console.WriteLine("Sorry! You wrote nothing here. Please add at least one symbol.Try again!");
			}
			else
			{
				check = false;
			}
		}
		return textInput;
		//public int CheckNumberInput()					//en metod fär att kolla om användaren skriver siffror
		//	{
		//		bool checkIfNumberInput = false;
		//		int value = -1;
		//		while (checkIfNumberInput == false)
		//		{
		//			bool checkInput = int.TryParse(Console.ReadLine(), out value);
		//			if (checkInput == false)
		//			{
		//				Console.WriteLine("Wrong input! Write just numbers please:");
		//			}
		//			else
		//			{
		//				checkIfNumberInput = true;
		//			}
		//		}
		//		return value;
		//	}
	}

	public void PrintString(string output)
	{
		Console.WriteLine(output);
	}
}
