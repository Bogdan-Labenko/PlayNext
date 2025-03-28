using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class PopularityType
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("popularity_source")]
    public PopularitySourceType PopularitySource { get; set; }
}