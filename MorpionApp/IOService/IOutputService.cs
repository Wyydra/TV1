namespace MorpionApp.IOService;

public interface IOutputService
{
    void Write(string message);
    void WriteLine(string msg);
    void Clear();
}