using MorpionApp;

public class MockPlayer : Player
{
    public MockPlayer(char symbol) : base(symbol)
    {
    }

    public override Position ReadInput(Game game, string msg)
    {
        throw new NotImplementedException();
    }
}
