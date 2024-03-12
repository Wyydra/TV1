namespace MorpionApp;

public interface ISwitchPlayerStrategy
{
    Player SwitchPlayer(Player? currentPlayer, Player[] players);
}