using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MorpionApp.Save;

public class GameConverter: JsonConverter
{
    
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Game);
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var game = (Game)value;
        var json = new JObject
        {
            { "gametype", JToken.FromObject(game.GetType().Name) },
            {"game",JToken.FromObject(game)}
        };
        writer.WriteValue(json);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var json = JObject.Load(reader);
        string gameType = json["gametype"].Value<string>();
        Type actualType = Type.GetType($"MorpionApp.{gameType}");
        return json["game"].ToObject(actualType,serializer);
    }
}