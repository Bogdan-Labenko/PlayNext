using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class Keyword
{
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}