using MorpionApp.IOService;
using MorpionApp.Save;
using Newtonsoft.Json;

namespace MorpionApp;

public abstract class Game
{
    [JsonProperty]
    protected Player? CurrentPlayer;
    [JsonProperty]
    public readonly int Width;
    [JsonProperty]
    public readonly int Height;

    [JsonProperty]
    private Grid _grid;
    [JsonProperty]
    private Player[] _players;
    private IOutputService _outputService;
    private ISwitchPlayerStrategy _switchPlayerStrategy;
    public ISwitchPlayerStrategy SwitchPlayerStrategy
    {
        set => _switchPlayerStrategy = value;
    }
    private ISaveStrategy _saveStrategy;
    public ISaveStrategy SaveStrategy
    {
        set => _saveStrategy = value;
    }

    public static void FromSave(Type actual, GameSave save)
    {
        // call actual type constructor not game constructor
        var game = (Game)Activator.CreateInstance(actual, save.Width, save.Height, save.Players, save.CurrentPlayer, save.Grid);
        
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != this.GetType()) return false;
        var game = (Game) obj;
        return Width == game.Width
               && Height == game.Height
               && _grid.Equals(game._grid)
               && _players.SequenceEqual(game._players)
               && (CurrentPlayer == null && game.CurrentPlayer == null || CurrentPlayer.Equals(game.CurrentPlayer));
    }

    protected Game(int width, int height, Player[] players,Player currentPlayer, Grid grid)
    {
        this.Width = width;
        this.Height = height;
        _grid = grid;
        _players = players;
        _switchPlayerStrategy = new SImpleSwitchPlayer();
        _outputService = new ConsoleOutput();
        _saveStrategy = new JsonSave();
    }
    
    
    protected Game(IOutputService outputService, int width, int height, Player[] players)
    {
        this.Width = width;
        this.Height = height;
        _grid = new Grid(outputService,width, height);
        _players = players;
        _switchPlayerStrategy = new SImpleSwitchPlayer();
        this._outputService = _outputService;
        _saveStrategy = new JsonSave();
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
            Save();
        }
    }
    public void Save()
    {
        _saveStrategy.Save("save.json", this);
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