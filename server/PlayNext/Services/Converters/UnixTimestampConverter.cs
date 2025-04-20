using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlayNextServer.Services.Converters;

public class UnixTimestampConverter : JsonConverter<DateTime?>
{
    private const long MinValidUnixTime = -62135596800;
    private const long MaxValidUnixTime = 253402300799;

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long unixTime))
        {
            if (unixTime < MinValidUnixTime || unixTime > MaxValidUnixTime)
                return null;

            return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
        }

        throw new JsonException($"Unexpected token parsing DateTime. Expected Number or Null, got {reader.TokenType}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            var unixTime = new DateTimeOffset(value.Value).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}