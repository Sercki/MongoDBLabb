using MongoDB.Driver.Core.Events;

internal interface IStringIO
{
	public string GetString();

	public void PrintString(string output);

	public void Clear();

	public void Exit();
}
