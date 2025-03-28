using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class PlatformLogo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("alpha_channel")]
    public bool AlphaChanel { get; set; }
    
    [JsonPropertyName("animated")]
    public bool Animated { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("height")]
    public int? Height { get; set; }
    
    [JsonPropertyName("width")]
    public int? Width { get; set; }
    
    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}