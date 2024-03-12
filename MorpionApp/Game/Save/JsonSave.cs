using Newtonsoft.Json;

namespace MorpionApp.Save;

public class JsonSave: ISaveStrategy
{
    public void Save(string path, Game game)
    {
        var json = JsonConvert.SerializeObject(new
        {
            gametype = game.GetType().Name, game,
        }, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static Game Load(string path)
    {
        var json = File.ReadAllText(path);
        var obj = JsonConvert.DeserializeObject<dynamic>(json);
        var gameType = Type.GetType($"MorpionApp.{obj.gametype}");
        return (Game)JsonConvert.DeserializeObject(obj.game.ToString(), gameType);
    }
}