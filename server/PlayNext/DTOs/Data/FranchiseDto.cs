using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class FranchiseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    [JsonPropertyName("games")]
    public IList<int>? GamesId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}