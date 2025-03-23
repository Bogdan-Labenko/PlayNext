using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class GameLocalization
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("cover")]
    public int? CoverId { get; set; }
    
    public Cover? Cover { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("game")]
    public int GameId { get; set; }
    
    public Game? Game { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("region")]
    public int RegionId { get; set; }
    
    public Region? Region { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}