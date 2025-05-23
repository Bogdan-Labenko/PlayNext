using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class LanguageDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("native_name")]
    public string? NativeName { get; set; }
}