
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MorpionApp.Save;

public class PlayerConverter: JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var player = (Player)value;
        var json = new JObject
        {
            { "playerType", JToken.FromObject(player.GetType().Name) },
            {"player",JToken.FromObject(player)}
        };
        writer.WriteValue(json);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var json = JObject.Load(reader);
        string playerType = json["playerType"].Value<string>();
        Type actualType = Type.GetType($"MorpionApp.{playerType}");
        return json["player"].ToObject(actualType);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Player);
    }
}