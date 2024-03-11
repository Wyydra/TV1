namespace MorpionApp;

public class TicTacToeGame: Game
{
    public TicTacToeGame(Player[] players) : base(3, 3, players)
    {
    }

    protected override void DoTurn()
    {
        Position position;
        do
        {
            position = CurrentPlayer!.ReadInput(this, "Enter a position (row, column): ");
        } while (!IsValidMove(position));
        SetCell(position, CurrentPlayer.Symbol);
        
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