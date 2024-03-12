namespace MorpionApp.IOService;

public class ConsoleOutput: IOutputService
{
    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string msg)
    {
        Console.WriteLine(msg);
    }

    public void Clear()
    {
        Console.Clear();
    }
}