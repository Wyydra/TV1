namespace MorpionApp;

public class HumanPlayer: Player
{
    public HumanPlayer(object avatar) : base(avatar)
    {
    }

    public override Position MakeMove(Game game, IInputService inputService)
    {
        inputService.ReadInput(game,"Enter your move:");
    }
}