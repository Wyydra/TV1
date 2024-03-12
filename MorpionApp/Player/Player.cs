namespace MorpionApp;

public abstract class Player
{
    public char Symbol { get; }

    protected Player(char symbol)
    {
        Symbol = symbol;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != this.GetType()) return false;
        var player = (Player) obj;
        return Symbol == player.Symbol;
    }

    public abstract Position ReadInput(Game game, string msg);
}