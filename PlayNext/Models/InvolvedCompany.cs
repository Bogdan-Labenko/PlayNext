using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class InvolvedCompany
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("company")]
    public int? CompanyId { get; set; }
    
    [JsonPropertyName("developer")]
    public bool IsDeveloper { get; set; }
    
    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    [JsonPropertyName("porting")]
    public bool IsPorting { get; set; }
    
    [JsonPropertyName("publisher")]
    public bool IsPublisher { get; set; }
    
    [JsonPropertyName("supporting")]
    public bool IsSupporting { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}