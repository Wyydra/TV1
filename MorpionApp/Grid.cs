namespace MorpionApp;

public class Grid
{
    public const int CellWidth = 3;
    public const int CellHeight = 3;
    public const char EmptyCell = '\0';
    
    public readonly int Width;
    public readonly int Height;
    private char[,] _grid;
    
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        _grid = new char[width, height];
        for (var i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                _grid[j, i] = EmptyCell;
            }
        }
    }
    public bool IsValidPosition(Position position)
    {
        return position.Row >= 0 
               && position.Row < Height 
               && position.Column >= 0 
               && position.Column < Width 
               && _grid[position.Column, position.Row] == EmptyCell;
    }
    public void SetCell(Position position, char symbol)
    {
        _grid[position.Column, position.Row] = symbol;
    }
    public char GetCell(Position position)
    {
        return _grid[position.Column, position.Row];
    }
    public bool CheckWin(char symbol, Position position)
    {
        return CheckRow(symbol,position) || CheckColumn(symbol,position) || CheckDiagonal(symbol,position);
    }
    public bool CheckDraw()
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
    public bool CheckRow(char symbol, Position position)
    {
        for (var i = 0; i < Width; i++)
        {
            if (_grid[i, position.Row] != symbol)
            {
                return false;
            }
        }
        return true;
    }
    public bool CheckColumn(char symbol, Position position)
    {
        for (var i = 0; i < Height; i++)
        {
            if (_grid[position.Column, i] != symbol)
            {
                return false;
            }
        }
        return true;
    }
    public bool CheckDiagonal(char symbol, Position position)
    {
        if (position.Row == position.Column)
        {
            for (var i = 0; i < Width; i++)
            {
                if (_grid[i, i] != symbol)
                {
                    return false;
                }
            }
            return true;
        }
    
        if (position.Row + position.Column != Width - 1) return false;
            
        for (var i = 0; i < Width; i++)
        {
            if (_grid[i, Width - 1 - i] != symbol)
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
}