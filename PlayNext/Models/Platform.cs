using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class Platform
{
    public int Id { get; set; }
    
    [JsonPropertyName("abbreviation")]
    public string? Abbreviation { get; set; }

    [JsonPropertyName("alternative_name")]
    public string? AlternativeName { get; set; }

    [JsonPropertyName("category")]
    public PlatformType Category { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("generation")]
    public int? Generation { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("platform_family")]
    public int? PlatformFamilyId { get; set; }
    
    public PlatformFamily? PlatformFamily { get; set; }

    [JsonPropertyName("platform_logo")]
    public int? PlatformLogoId { get; set; }
    
    public PlatformLogo? PlatformLogo { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}