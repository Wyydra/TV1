namespace MorpionApp;

public abstract class Player
{
   public object Avatar { get; set; }
   public Player(object avatar)
   {
       Avatar = avatar;
   }
   public abstract Position MakeMove(Game game, IInputService inputService);
}