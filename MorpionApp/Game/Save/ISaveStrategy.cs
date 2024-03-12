namespace MorpionApp.Save;

public interface ISaveStrategy
{
    void Save(string path, Game game);
}