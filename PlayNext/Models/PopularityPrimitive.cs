using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class PopularityPrimitive
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("calculated_at")]
    public DateTime? CalculatedAt { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("game_id")]
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }

    [JsonPropertyName("popularity_source")]
    public PopularitySourceType? PopularitySource { get; set; }

    [JsonPropertyName("popularity_type")]
    public int PopularityType { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("value")]
    public decimal Value { get; set; }
}