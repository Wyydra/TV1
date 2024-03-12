using MorpionApp;
using MorpionApp.IOService;
using Xunit.Abstractions;

namespace MorpionAppTest;
public class GridTests
{
    private readonly ITestOutputHelper output;
    private readonly IOutputService _outputService;
    public GridTests(ITestOutputHelper output)
    {
        this.output = output;
        _outputService = new TestOutputService(output);
    }
    [Fact]
    public void IsValidMove_ValidPosition_ReturnsTrue()
    {
        var grid = new Grid(_outputService,3, 3);

        var result = grid.IsValidPosition(new Position(1, 1));

        Assert.True(result);
    }

    [Fact]
    public void IsValidMove_InvalidPosition_ReturnsFalse()
    {
        var grid = new Grid(_outputService,3, 3);

        var result = grid.IsValidPosition(new Position(3, 3));

        Assert.False(result);
    }

    [Fact]
    public void SetCell_ValidPosition_CellSet()
    {
        var grid = new Grid(_outputService,3, 3);

        grid.SetCell(new Position(1, 1), 'X');

        Assert.Equal('X', grid.GetCell(new Position(1, 1)));
    }

    [Fact]
    public void CheckWin_WinningPosition_ReturnsTrue()
    {
        var grid = new Grid(_outputService,3, 3);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'X');

        var result = grid.CheckWin('X');

        Assert.True(result);
    }

    [Fact]
    public void CheckWin_NonWinningPosition_ReturnsFalse()
    {
        var grid = new Grid(_outputService,3, 3);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'O');

        var result = grid.CheckWin('X');

        Assert.False(result);
    }

    [Fact]
    public void CheckDraw_NoEmptyCells_ReturnsTrue()
    {
        var grid = new Grid(_outputService,3, 3);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                grid.SetCell(new Position(i, j), 'X');
            }
        }

        var result = grid.CheckDraw();

        Assert.True(result);
    }

    [Fact]
    public void CheckDraw_EmptyCells_ReturnsFalse()
    {
        var grid = new Grid(_outputService,3, 3);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                grid.SetCell(new Position(i, j), i == j ? 'X' : Grid.EmptyCell);
            }
        }

        var result = grid.CheckDraw();

        Assert.False(result);
    }
    [Fact]
    public void CheckDiagonalBig_WinningPosition_ReturnsTrue()
    {
        var grid = new Grid(_outputService,7, 4);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'X');
        grid.SetCell(new Position(3, 3), 'X');
        
        var result = grid.CheckWin('X');

        Assert.True(result);
    }
    [Fact]
    public void CheckDiagonalBig_NonWinningPosition_ReturnsFalse()
    {
        var grid = new Grid(_outputService,7, 6);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'O');
        grid.SetCell(new Position(3, 3), 'X');

        var result = grid.CheckWin('X');

        Assert.False(result);
    }
    [Fact]
    public void CheckDraw_EmptyGrid_ReturnsFalse()
    {
        var grid = new Grid(_outputService,3, 3);

        var result = grid.CheckDraw();

        Assert.False(result);
    }

    [Fact]
    public void CheckDraw_GridFilledWithDifferentSymbolsNoWinner_ReturnsTrue()
    {
        var grid = new Grid(_outputService,3, 3);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                var symbol = (i + j) % 2 == 0 ? 'X' : 'O';
                grid.SetCell(new Position(i, j), symbol);
            }
        }

        var result = grid.CheckDraw();

        Assert.True(result);
    }
}