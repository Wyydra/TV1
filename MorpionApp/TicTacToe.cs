namespace MorpionApp; 

public class TicTacToeGame: Game
{
    public TicTacToeGame(Player[] players) : base(3, 3, players) { }

    protected override void DoTurn()
    {
        var position = _currentPlayer?.MakeMove(_inputService);
    }

    protected override bool IsFinished { get; set; }

    private bool IsFull()
    {
        for (var i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (_grid[i, j] == '\0')
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool IsWinningMove(int x, int y)
    {
        char player = _grid[x, y];
        if (player == '\0')
        {
            return false;
        }
        return IsWinningRow(x, y, player) || IsWinningColumn(x, y, player) || IsWinningDiagonal(x, y, player);
    } 
    private bool IsWinningRow(int x, int y, char player)
    {
        for (int i = 0; i < width; i++)
        {
            if (_grid[i, y] != player)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsWinningColumn(int x, int y, char player)
    {
        for (int i = 0; i < height; i++)
        {
            if (_grid[x, i] != player)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsWinningDiagonal(int x, int y, char player)
    {
        if (x == y)
        {
            for (int i = 0; i < width; i++)
            {
                if (_grid[i, i] != player)
                {
                    return false;
                }
            }
            return true;
        }
        if (x + y == width - 1)
        {
            for (int i = 0; i < width; i++)
            {
                if (_grid[i, width - 1 - i] != player)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}