using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class PlatformDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; }
    
    [JsonPropertyName("alternative_name")]
    public string AlternativeName { get; set; }
    
    [JsonPropertyName("generation")]
    public int Generation { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("platform_logo")]
    public int? PlatformLogoId { get; set; }
    
    [JsonPropertyName("platform_type")]
    public int? PlatformTypeId { get; set; }
    
    [JsonPropertyName("slug")]
    public string Slug { get; set; }
    
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
    
    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}