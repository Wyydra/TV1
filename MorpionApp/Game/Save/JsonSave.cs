using Newtonsoft.Json;

namespace MorpionApp.Save;

public class JsonSave: ISaveStrategy
{
    public void Save(string path, Game game)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            
            //Converters = new List<JsonConverter> { new GameConverter(), new PlayerConverter() }
        };
        var json = JsonConvert.SerializeObject(game, settings);
        File.WriteAllText(path, json);
    }

    public static Game Load(string path)
    {
        var json = File.ReadAllText(path);
        var settings = new JsonSerializerSettings();
        settings.TypeNameHandling = TypeNameHandling.All;
        //settings.Converters.Add(new GameConverter());
        //settings.Converters.Add(new PlayerConverter());
        return JsonConvert.DeserializeObject<Game>(json, settings); 
    }
}