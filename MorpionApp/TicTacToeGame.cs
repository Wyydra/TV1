using MorpionApp.IOService;

namespace MorpionApp;

public class TicTacToeGame: Game
{
    public TicTacToeGame(IOutputService outputService,Player[] players) : base(outputService,3, 3, players)
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
        Draw();
        
        if (CheckWin())
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