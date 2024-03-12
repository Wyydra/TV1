using MorpionApp;

namespace MorpionAppTest;

public class SimpleSwitchPlayerStrategyTests
{
    [Fact]
    public void SwitchPlayer_CurrentPlayerIsNull_ReturnsFirstPlayer()
    {
        Player[] players = { new MockPlayer('X'), new MockPlayer('O') };
        var strategy = new SimpleSwitchPlayerStrategy();

        var result = strategy.SwitchPlayer(null, players);

        Assert.Equal(players[0], result);
    }

    [Fact]
    public void SwitchPlayer_CurrentPlayerIsFirstPlayer_ReturnsSecondPlayer()
    {
        Player[] players = { new MockPlayer('X'), new MockPlayer('O') };
        var strategy = new SimpleSwitchPlayerStrategy();

        var result = strategy.SwitchPlayer(players[0], players);

        Assert.Equal(players[1], result);
    }

    [Fact]
    public void SwitchPlayer_CurrentPlayerIsLastPlayer_ReturnsFirstPlayer()
    {
        Player[] players = { new MockPlayer('X'), new MockPlayer('O') };
        var strategy = new SimpleSwitchPlayerStrategy();

        var result = strategy.SwitchPlayer(players[1], players);

        Assert.Equal(players[0], result);
    }
}