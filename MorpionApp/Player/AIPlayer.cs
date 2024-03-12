namespace MorpionApp;

public class AIPlayer: Player
{
    public AIPlayer(char symbol) : base(symbol)
    {
    }

    public override Position ReadInput(Game game, string msg)
    {
        int row = new Random().Next(0, game.Height);
        int col = new Random().Next(0, game.Width);
        return new Position(row, col);
    }
}