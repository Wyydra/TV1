using MorpionApp.IOService;

namespace MorpionApp;

public abstract class Game
{
    protected Player? CurrentPlayer;
    public readonly int Width;
    public readonly int Height;

    private Grid _grid;
    private Player[] _players;
    private ISwitchPlayerStrategy _switchPlayerStrategy;
    private IOutputService _outputService;
    public ISwitchPlayerStrategy SwitchPlayerStrategy
    {
        set => _switchPlayerStrategy = value;
    }

    protected Game(IOutputService outputService, int width, int height, Player[] players)
    {
        this.Width = width;
        this.Height = height;
        _grid = new Grid(outputService,width, height);
        _players = players;
        _switchPlayerStrategy = new SimpleSwitchPlayerStrategy();
        this._outputService = _outputService;
    }

    protected bool IsFinished { get; set; }
    public void Play()
    {
        IsFinished = false;
        while (!IsFinished)
        {
            Draw();
            SwitchPlayer();
            DoTurn();
        }
    }
    public void Draw()
    {
        _grid.Draw();
    }
    protected bool IsValidMove(Position position)
    {
        return _grid.IsValidPosition(position);
    }
    protected void SetCell(Position position, char symbol)
    {
        _grid.SetCell(position, symbol);
    }
    protected char GetCell(Position position)
    {
        return _grid.GetCell(position);
    }
    protected bool CheckWin()
    {
        return _grid.CheckWin(CurrentPlayer!.Symbol);
    }
    protected bool CheckDraw()
    {
        var res = _grid.CheckDraw();
        // loop over all players to check if they won
        if (!res) return res;
        return !_players.Any(player => _grid.CheckWin(player.Symbol));
    }
    private void SwitchPlayer()
    {
        CurrentPlayer = _switchPlayerStrategy.SwitchPlayer(CurrentPlayer, _players); 
    }
    protected abstract void DoTurn();
}