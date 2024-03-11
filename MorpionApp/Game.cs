namespace MorpionApp;

public abstract class Game
{
    private char[,] _grid;
    private int width, height;
    private IInputService _inputService;
    private IOutputService _outputService;

    protected Game(int width, int height)
    {
        this.width = width;
        this.height = height;
        _grid = new char[width, height];
        this._inputService = new ConsoleInputService();
        this._outputService = new ConsoleOutputService();
    }
    
    public abstract void DoTurn();
}