namespace MorpionApp;

public abstract class Game
{
    protected Player? CurrentPlayer;
    public readonly int Width;
    public readonly int Height;

    public const int CellWidth = 4;
    public const int CellHeight = 4;

    protected const char EmptyCell = '\0';

    private char[,] _grid;
    private Player[] _players;

    protected Game(int width, int height, Player[] players)
    {
        this.Width = width;
        this.Height = height;
        _grid = new char[width, height];
        for (var i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                _grid[j, i] = EmptyCell;
            }
        }
        _players = players;
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

    protected bool IsValidMove(Position position)
    {
        return position.Row >= 0 
               && position.Row < Height 
               && position.Column >= 0 
               && position.Column < Width 
               && _grid[position.Column, position.Row] == EmptyCell;
    }
    protected void SetCell(Position position, char symbol)
    {
        _grid[position.Column, position.Row] = symbol;
    }
    protected char GetCell(Position position)
    {
        return _grid[position.Column, position.Row];
    }
    protected bool CheckWin(Position position)
    {
        return CheckRow(position) || CheckColumn(position) || CheckDiagonal(position);
    }
    protected bool CheckDraw()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                if (_grid[j, i] == EmptyCell)
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool CheckRow(Position position)
    {
        for (var i = 0; i < Width; i++)
        {
            if (_grid[i, position.Row] != CurrentPlayer!.Symbol)
            {
                return false;
            }
        }
        return true;
    }
    private bool CheckColumn(Position position)
    {
        for (var i = 0; i < Height; i++)
        {
            if (_grid[position.Column, i] != CurrentPlayer!.Symbol)
            {
                return false;
            }
        }
        return true;
    }
    private bool CheckDiagonal(Position position)
    {
        if (position.Row == position.Column)
        {
            for (var i = 0; i < Width; i++)
            {
                if (_grid[i, i] != CurrentPlayer!.Symbol)
                {
                    return false;
                }
            }
            return true;
        }

        if (position.Row + position.Column != Width - 1) return false;
        
        for (var i = 0; i < Width; i++)
        {
            if (_grid[i, Width - 1 - i] != CurrentPlayer!.Symbol)
            {
                return false;
            }
        }
        return true;
    }
    public void Draw()
    {
        Console.Clear();
        for (var i = 0; i < Height; i++)
        {
            DrawRow(i);
            if (i < Height - 1) DrawSeparator();
        }
    }

    private void DrawRow(int rowIndex)
    {
        for (var j = 0; j < Width; j++)
        {
            var symbol = _grid[j, rowIndex] != EmptyCell ? _grid[j, rowIndex].ToString() : " ";
            var padding = (CellWidth - symbol.Length) / 2;
            var paddedSymbol = new string(' ', padding) + symbol + new string(' ', CellWidth - padding - symbol.Length);
            Console.Write(paddedSymbol);
            if (j < Width - 1) Console.Write("|");
        }
        Console.WriteLine();
    }

    private void DrawSeparator()
    {
        for (var j = 0; j < Width; j++)
        {
            Console.Write(new string('-', CellHeight));
            if (j < Width - 1) Console.Write("+");
        }
        Console.WriteLine();
    }
    protected virtual void SwitchPlayer()
    {
        if (CurrentPlayer == null)
        {
            CurrentPlayer = _players[0];
        }
        else
        {
            var index = Array.IndexOf(_players, CurrentPlayer);
            CurrentPlayer = _players[(index + 1) % _players.Length];
        }
    }

    protected abstract void DoTurn();
}