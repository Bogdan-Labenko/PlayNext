using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class LanguageSupport
{
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }
    
    [JsonPropertyName("language")]
    public int? LanguageId { get; set; }
    
    public Language? Language { get; set; }
    
    [JsonPropertyName("language_support_type")]
    public int? LanguageSupportTypeId { get; set; }
    
    public LanguageSupportType? LanguageSupportType { get; set; }
}