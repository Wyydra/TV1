using MorpionApp;

namespace MorpionAppTest;
public class GridTests
{
    [Fact]
    public void IsValidMove_ValidPosition_ReturnsTrue()
    {
        var grid = new Grid(3, 3);

        var result = grid.IsValidPosition(new Position(1, 1));

        Assert.True(result);
    }

    [Fact]
    public void IsValidMove_InvalidPosition_ReturnsFalse()
    {
        var grid = new Grid(3, 3);

        var result = grid.IsValidPosition(new Position(3, 3));

        Assert.False(result);
    }

    [Fact]
    public void SetCell_ValidPosition_CellSet()
    {
        var grid = new Grid(3, 3);

        grid.SetCell(new Position(1, 1), 'X');

        Assert.Equal('X', grid.GetCell(new Position(1, 1)));
    }

    [Fact]
    public void CheckWin_WinningPosition_ReturnsTrue()
    {
        var grid = new Grid(3, 3);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'X');

        var result = grid.CheckWin('X',new Position(2, 2));

        Assert.True(result);
    }

    [Fact]
    public void CheckWin_NonWinningPosition_ReturnsFalse()
    {
        var grid = new Grid(3, 3);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'O');

        var result = grid.CheckWin('X',new Position(2, 2));

        Assert.False(result);
    }

    [Fact]
    public void CheckDraw_NoEmptyCells_ReturnsTrue()
    {
        var grid = new Grid(3, 3);
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
        var grid = new Grid(3, 3);
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
        var grid = new Grid(7, 6);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'X');
        grid.SetCell(new Position(3, 3), 'X');

        var result = grid.CheckDiagonal('X',new Position(3, 3));

        Assert.True(result);
    }
    [Fact]
    public void CheckDiagonalBig_NonWinningPosition_ReturnsFalse()
    {
        var grid = new Grid(7, 6);
        grid.SetCell(new Position(0, 0), 'X');
        grid.SetCell(new Position(1, 1), 'X');
        grid.SetCell(new Position(2, 2), 'O');
        grid.SetCell(new Position(3, 3), 'X');

        var result = grid.CheckDiagonal('X', new Position(3, 3));

        Assert.False(result);
    }
}