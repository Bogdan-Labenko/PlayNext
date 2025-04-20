using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class CoverDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("alpha_channel")]
    public bool AlphaChanel { get; set; }

    [JsonPropertyName("animated")]
    public bool Animated { get; set; }

    [JsonPropertyName("game")]
    public int GameId { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("image_id")]
    public string ImageId { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }
}