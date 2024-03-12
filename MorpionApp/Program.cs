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
                switch (gameChoice)
                {
                    case ConsoleKey.D1:
                        game = new TicTacToeGame(new Player[] { new HumanPlayer('X'), new HumanPlayer('O') });
                        game.Play();
                        break;
                    case ConsoleKey.D2:
                        game = new ConnectFour(new Player[] { new HumanPlayer('X'), new HumanPlayer('O') });
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
