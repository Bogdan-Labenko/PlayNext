using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class Region
{
    public int Id { get; set; }
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}