using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamParse.Converters;

public class EmptyArrayToNullConverter<T> : JsonConverter<T> where T : class
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            // Skip empty array and return null
            if (reader.Read() && reader.TokenType == JsonTokenType.EndArray)
                return null;
        }

        // if it object, standard handling
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}