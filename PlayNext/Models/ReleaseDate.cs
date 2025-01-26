using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class ReleaseDate
{ 
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("category")]
    public ReleaseDateType Category { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("game")]
    public int GameId { get; set; }
    
    public Game? Game { get; set; }

    [JsonPropertyName("human")]
    public string? Human { get; set; }

    [JsonPropertyName("m")]
    public int? Month { get; set; }

    [JsonPropertyName("platform")]
    public int? PlatformId { get; set; }
    
    public Platform? Platform { get; set; }

    [JsonPropertyName("region")]
    public RegionEnum Region { get; set; }

    [JsonPropertyName("status")]
    public int? StatusId { get; set; }
    
    public ReleaseDateStatus? Status { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("y")]
    public int? Year { get; set; }
}