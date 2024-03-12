namespace MorpionApp;

public abstract class Player
{
    public char Symbol { get; }

    protected Player(char symbol)
    {
        Symbol = symbol;
    }

    public abstract Position ReadInput(Game game, string msg);
}