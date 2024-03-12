using MorpionApp;
using MorpionApp.IOService;
using MorpionApp.Save;
using Newtonsoft.Json;

namespace MorpionAppTest;

public class JsonSaveTests: IDisposable
{
    private string _filePath = "test.json";
    private JsonSave _jsonSave;

    public JsonSaveTests()
    {
        _jsonSave = new JsonSave();
    }

    [Fact]
    public void Save_WritesTicTacToeGameToJsonFile()
    {
        var game = new TicTacToeGame(new ConsoleOutput(), new Player[] { new MockPlayer('X'), new MockPlayer('O') });

        _jsonSave.Save(_filePath, game);

        Assert.True(File.Exists(_filePath));
        var json = File.ReadAllText(_filePath);

        var serializedGame = @"{""$type"":""MorpionApp.TicTacToeGame, MorpionApp"",""CurrentPlayer"":null,""Width"":3,""Height"":3,""_grid"":{""$type"":""MorpionApp.Grid, MorpionApp"",""Width"":3,""Height"":3,""_grid"":{""$type"":""System.Char[,], System.Private.CoreLib"",""$values"":[[""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000""]]},""CellWidth"":4,""CellHeight"":4,""EmptyCell"":""\u0000""},""_players"":{""$type"":""MorpionApp.Player[], MorpionApp"",""$values"":[{""$type"":""MockPlayer, MorpionAppTest"",""Symbol"":""X""},{""$type"":""MockPlayer, MorpionAppTest"",""Symbol"":""O""}]}}";
    
        Assert.Equal(serializedGame, json);
    }

    [Fact]
    public void Load_ReadsTicTacToeGameFromJsonFile()
    {
        var game = new TicTacToeGame(new ConsoleOutput(), new Player[] { new MockPlayer('X'), new MockPlayer('O') });
        _jsonSave.Save(_filePath, game);

        var loadedGame = JsonSave.Load(_filePath);

        Assert.True(loadedGame.Equals(game));
    }

    [Fact]
    public void Save_WritesConnectFourToJsonFile()
    {
        var game = new ConnectFour(new ConsoleOutput(), new Player[] { new MockPlayer('X'), new MockPlayer('O') });

        _jsonSave.Save(_filePath, game);

        Assert.True(File.Exists(_filePath));
        var json = File.ReadAllText(_filePath);
        var deserializedGame =
            @"{""$type"":""MorpionApp.ConnectFour, MorpionApp"",""CurrentPlayer"":null,""Width"":7,""Height"":4,""_grid"":{""$type"":""MorpionApp.Grid, MorpionApp"",""Width"":7,""Height"":4,""_grid"":{""$type"":""System.Char[,], System.Private.CoreLib"",""$values"":[[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""],[""\u0000"",""\u0000"",""\u0000"",""\u0000""]]},""CellWidth"":4,""CellHeight"":4,""EmptyCell"":""\u0000""},""_players"":{""$type"":""MorpionApp.Player[], MorpionApp"",""$values"":[{""$type"":""MockPlayer, MorpionAppTest"",""Symbol"":""X""},{""$type"":""MockPlayer, MorpionAppTest"",""Symbol"":""O""}]}}";
        Assert.Equal(deserializedGame,json);
    }

    [Fact]
    public void Load_ReadsConnectFourFromJsonFile()
    {
        var game = new ConnectFour(new ConsoleOutput(), new Player[] { new MockPlayer('X'), new MockPlayer('O') });
        _jsonSave.Save(_filePath, game);

        var loadedGame = JsonSave.Load(_filePath);

        Assert.Equal(game, loadedGame);
    }

    public void Dispose()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }
}