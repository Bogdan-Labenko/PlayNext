using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class AlternativeNameDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("game")]
    public int GameId { get; set; }

    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
}