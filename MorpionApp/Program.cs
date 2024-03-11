namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new TicTacToeGame( new  Player[] { new HumanPlayer('X'), new HumanPlayer('O') }) ;
            game.Play();
        }        
    }
}
