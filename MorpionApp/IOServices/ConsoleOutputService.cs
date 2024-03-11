namespace MorpionApp;

public class ConsoleOutputService: IOutputService
{
    public void Write(string output)
    {
        Console.WriteLine(output);
    }
}