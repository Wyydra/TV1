using MorpionApp.IOService;
using Newtonsoft.Json;

namespace MorpionApp;

public class Grid
{
    [JsonProperty]
    public const int CellWidth = 4;
    [JsonProperty]
    public const int CellHeight = 4;
    [JsonProperty]
    public const char EmptyCell = '\0';
    
    [JsonProperty]
    public readonly int Width;
    [JsonProperty]
    public readonly int Height;
    
    [JsonProperty]
    private char[,] _grid;
    private IOutputService _outputService;
    
    public Grid(IOutputService outputService, int width, int height)
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
        this._outputService = outputService ?? new ConsoleOutput();
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
    public bool CheckWin(char symbol)
    {
        // generate mask length based on the grid size
        var length = Math.Min(Width, Height);
        var horizontalMask = GenerateHorizontalMask(length);
        var verticalMask = GenerateVerticalMask(length);
        var mainDiagonalMask = GenerateMainDiagonalMask(length, length);
        var counterDiagonalMask = GenerateCounterDiagonalMask(length, length);
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                var position = new Position(i, j);
                if (CheckMask(horizontalMask, symbol, length, position) 
                    || CheckMask(verticalMask, symbol, length, position) 
                    || CheckMask(mainDiagonalMask, symbol, length, position) 
                    || CheckMask(counterDiagonalMask, symbol, length, position))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckMask(int[,] mask, char symbol, int length, Position position)
    {
        var (x,y) = (position.Column, position.Row);
        var maskRows = mask.GetLength(0);
        var maskCols = mask.GetLength(1);
        if (x + maskCols > Width || y + maskRows > Height)
        {
            return false;
        }
        for (var i = 0; i < maskRows; i++)
        {
            for (var j = 0; j < maskCols; j++)
            {
                if (mask[i, j] == 1 && _grid[x + j, y + i] != symbol)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static int[,] GenerateHorizontalMask(int width)
    {
        var mask = new int[1, width];
        for (var i = 0; i < width; i++)
        {
            mask[0, i] = 1;
        }
        return mask;
    }

    private static int[,] GenerateVerticalMask(int height)
    {
        var mask = new int[height, 1];
        for (var i = 0; i < height; i++)
        {
            mask[i, 0] = 1;
        }
        return mask;
    }

    private static int[,] GenerateMainDiagonalMask(int width, int height)
    {
        var minSize = Math.Min(width, height);
        var mask = new int[minSize, minSize];
        for (var i = 0; i < minSize; i++)
        {
            mask[i, i] = 1;
        }
        return mask;
    }

    private static int[,] GenerateCounterDiagonalMask(int width, int height)
    {
        var minSize = Math.Min(width, height);
        var mask = new int[minSize, minSize];
        for (var i = 0; i < minSize; i++)
        {
            mask[i, minSize - i - 1] = 1;
        }
        return mask;
    }
    public void Draw()
    {
        _outputService.Clear();
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
            _outputService.Write(paddedSymbol);
            if (j < Width - 1) _outputService.Write("|");
        }
        _outputService.WriteLine("");
    }
    private void DrawSeparator()
    {
        for (var j = 0; j < Width; j++)
        {
            _outputService.Write(new string('-', CellHeight));
            if (j < Width - 1) _outputService.Write("+");
        }
        _outputService.WriteLine("");
    }
}