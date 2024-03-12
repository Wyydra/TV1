namespace MorpionApp;

public class SimpleSwitchPlayerStrategy : ISwitchPlayerStrategy
{
    public Player SwitchPlayer(Player? currentPlayer, Player[] players)
    {
        if (currentPlayer == null)
        {
            return players[0];
        }
        else
        {
            var index = Array.IndexOf(players, currentPlayer);
            return players[(index + 1) % players.Length];
        }
    }
}