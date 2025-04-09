using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class GameTypeDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
}