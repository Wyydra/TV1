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
    public bool CheckWin(char symbol, int length)
    {
        var mask = new int[length];
        for (var i = 0; i < length; i++)
        {
            mask[i] = 1;
        }

        for (var i = 0; i < Height; i++)
        {
            if (ConvolveRow(i, symbol, mask) == length)
            {
                return true;
            }
        }

        for (var i = 0; i < Width; i++)
        {
            if (ConvolveColumn(i, symbol, mask) == length)
            {
                return true;
            }
        }

        if (ConvolveMainDiagonal(symbol, mask) == length)
        {
            return true;
        }

        return ConvolveAntiDiagonal(symbol, mask) == length;
    }
    
    private int ConvolveRow(int rowIndex, char symbol, int[] mask)
    {
        var sum = 0;
        for (var i = 0; i < Width; i++)
        {
            if (_grid[i, rowIndex] == symbol)
            {
                sum += mask[i];
            }
        }
        return sum;
    }
    private int ConvolveColumn(int columnIndex, char symbol, int[] mask)
    {
        var sum = 0;
        for (var i = 0; i < Height; i++)
        {
            if (_grid[columnIndex, i] == symbol)
            {
                sum += mask[i];
            }
        }
        return sum;
    }
    private int ConvolveMainDiagonal(char symbol, IReadOnlyList<int> mask)
    {
        var sum = 0;
        var diagonalLength = Math.Min(Width, Height);
        for (var i = 0; i < diagonalLength; i++)
        {
            if (_grid[i, i] == symbol)
            {
                sum += mask[i];
            }
        }
        return sum;
    }

    private int ConvolveAntiDiagonal(char symbol, IReadOnlyList<int> mask)
    {
        var sum = 0;
        var diagonalLength = Math.Min(Width, Height);
        for (var i = 0; i < diagonalLength; i++)
        {
            if (_grid[Width - 1 - i, i] == symbol)
            {
                sum += mask[i];
            }
        }
        return sum;
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