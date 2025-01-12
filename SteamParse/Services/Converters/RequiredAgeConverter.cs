using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamParse.Converters;

public class RequiredAgeConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32().ToString();
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }
        throw new JsonException("Unexpected JSON token for required_age.");
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}