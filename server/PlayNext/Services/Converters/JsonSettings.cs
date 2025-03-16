using System.Text.Json;

namespace PlayNextServer.Services.Converters;

public static class JsonSettings
{
    public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        Converters =
        {
            new UnixTimestampConverter()
        }
    };
}