using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class GameEngine
{
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("logo")]
    public int? LogoId { get; set; }
    
    public GameEngineLogo? Logo { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}