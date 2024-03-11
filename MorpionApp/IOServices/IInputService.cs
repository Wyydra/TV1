namespace MorpionApp;

public interface IInputService
{
   Position? ReadInput(Game game, string msg); 
}