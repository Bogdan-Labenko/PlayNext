using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class GameVideo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }
    
    [JsonPropertyName("video_id")]
    public string? VideoId { get; set; }
}