using MorpionApp.IOService;
using Xunit.Abstractions;

namespace MorpionAppTest;

public class TestOutputService: IOutputService
{
    private ITestOutputHelper _outputService;
    public TestOutputService(ITestOutputHelper outputService)
    {
        _outputService = outputService;
    }
    public void Write(string message)
    {
        _outputService.WriteLine(message);
    }

    public void WriteLine(string msg)
    {
        _outputService.WriteLine(msg);
    }

    public void Clear()
    {
    }
}