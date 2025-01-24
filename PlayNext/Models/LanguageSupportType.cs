using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class LanguageSupportType
{
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}