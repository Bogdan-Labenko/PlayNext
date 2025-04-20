using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class LanguageSupportDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("game")]
    public int? GameId { get; set; }

    [JsonPropertyName("language")]
    public int? LanguageId { get; set; }

    [JsonPropertyName("language_support_type")]
    public int? LanguageSupportTypeId { get; set; }
}