using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class PlatformFamily
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
}