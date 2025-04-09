using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class GameEngineDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("logo")]
    public int? LogoId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}