namespace MorpionApp;

public class ConnectFour: Game
{
    public ConnectFour( Player[] players) : base(7, 4, players)
    {
    }

    protected override void DoTurn()
    {
        Position position;
        do
        {
            position = CurrentPlayer!.ReadInput(this, "Enter a column: ");
            // check last empty cell in column
            for (var i = Height - 1; i >= 0; i--)
            {
                if (GetCell(new Position(i,position.Column)) != Grid.EmptyCell) continue;
                position.Row = i;
                break;
            }
        } while (!IsValidMove(position));
        SetCell(position, CurrentPlayer.Symbol);
        Draw();
        
        if (CheckWin(position))
        {
            Console.WriteLine($"Player {CurrentPlayer.Symbol} wins!");
            IsFinished = true;
        }
        else if (CheckDraw())
        {
            Console.WriteLine("It's a draw!");
            IsFinished = true;
        }
    }
}