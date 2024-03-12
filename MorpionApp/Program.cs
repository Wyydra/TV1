using MorpionApp.IOService;

namespace MorpionApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var playAgain = true;
            while (playAgain)
            {
                Game game;
                Console.WriteLine("Choose a game: 1 for TicTacToe, 2 for ConnectFour");
                var gameChoice = Console.ReadKey().Key;
                Console.WriteLine("Choose an opponent: 1 for Human, 2 for AI");
                var opponentChoice = Console.ReadKey().Key;
                Player opponent = new HumanPlayer('O');
                switch (opponentChoice)
                {
                    case ConsoleKey.D1:
                        opponent = new HumanPlayer('O');
                        break;
                    case ConsoleKey.D2:
                        opponent = new AIPlayer('O');
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                        
                }
                var outputService = new ConsoleOutput();
                switch (gameChoice)
                {
                    case ConsoleKey.D1:
                        game = new TicTacToeGame(outputService,new[] { new HumanPlayer('X'), opponent });
                        game.Play();
                        break;
                    case ConsoleKey.D2:
                        game = new ConnectFour(outputService,new[] { new HumanPlayer('X'), opponent });
                        game.Play();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadKey().Key == ConsoleKey.Y;
            }
        }        
    }
}