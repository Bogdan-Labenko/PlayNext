using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class ReleaseDateDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("date_format")]
    public DateTime DateFormat { get; set; }
    
    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    [JsonPropertyName("platform")]
    public int? PlatformId { get; set; }
    
    [JsonPropertyName("status")]
    public int? StatusId { get; set; }
    
    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}