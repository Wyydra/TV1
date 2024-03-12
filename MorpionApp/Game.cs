namespace MorpionApp;

public abstract class Game
{
    protected Player? CurrentPlayer;
    public readonly int Width;
    public readonly int Height;

    private Grid _grid;
    private Player[] _players;
    private ISwitchPlayerStrategy _switchPlayerStrategy;
    public ISwitchPlayerStrategy SwitchPlayerStrategy
    {
        set => _switchPlayerStrategy = value;
    }

    protected Game(int width, int height, Player[] players)
    {
        this.Width = width;
        this.Height = height;
        _grid = new Grid(width, height);
        _players = players;
        _switchPlayerStrategy = new SimpleSwitchPlayerStrategy();
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
        return position.Row >= 0 
               && position.Row < Height 
               && position.Column >= 0 
               && position.Column < Width 
               && _grid.GetCell(position) == Grid.EmptyCell;
    }
    protected void SetCell(Position position, char symbol)
    {
        _grid.SetCell(position, symbol);
    }
    protected char GetCell(Position position)
    {
        return _grid.GetCell(position);
    }
    protected bool CheckWin(Position position)
    {
        return CheckRow(position) || CheckColumn(position) || CheckDiagonal(position);
    }
    protected bool CheckDraw()
    {
        return _grid.CheckDraw();
    }
    private bool CheckRow(Position position)
    {
        return _grid.CheckRow(CurrentPlayer!.Symbol,position);
    }
    private bool CheckColumn(Position position)
    {
        return _grid.CheckColumn(CurrentPlayer!.Symbol,position); 
    }
    private bool CheckDiagonal(Position position)
    {
        return _grid.CheckDiagonal(CurrentPlayer!.Symbol,position); 
    }
    protected void SwitchPlayer()
    {
        CurrentPlayer = _switchPlayerStrategy.SwitchPlayer(CurrentPlayer, _players); 
    }
    protected abstract void DoTurn();
}