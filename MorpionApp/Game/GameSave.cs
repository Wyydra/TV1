namespace MorpionApp;

public struct GameSave
{
    public readonly Player? CurrentPlayer;
    public readonly int Width;
    public readonly int Height;
    public readonly Grid Grid;
    public readonly Player[] Players;
    
    public GameSave(int width, int height, Player[] players, Grid grid, Player? currentPlayer)
    {
        CurrentPlayer = currentPlayer;
        Width = width;
        Height = height;
        Grid = grid;
        Players = players;
    }
}