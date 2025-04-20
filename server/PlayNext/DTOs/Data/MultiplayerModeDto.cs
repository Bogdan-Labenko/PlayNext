using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class MultiplayerModeDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("campaigncoop")]
    public bool HasCampaignCoop { get; set; }
    
    [JsonPropertyName("dropin")]
    public bool HasDropIn { get; set; }
    
    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    [JsonPropertyName("lancoop")]
    public bool HasLanCoop { get; set; }
    
    [JsonPropertyName("offlinecoop")]
    public bool HasOfflineCoop { get; set; }
    
    [JsonPropertyName("offlinecoopmax")]
    public int OfflineCoopMax { get; set; }
    
    [JsonPropertyName("offlinemax")]
    public int OfflineMax { get; set; }
    
    [JsonPropertyName("onlinecoop")]
    public bool HasOnlineCoop { get; set; }
    
    [JsonPropertyName("onlinecoopmax")]
    public int OnlineCoopMax { get; set; }
    
    [JsonPropertyName("onlinemax")]
    public int OnlineMax { get; set; }
    
    [JsonPropertyName("platform")]
    public int? PlatformId { get; set; }
    
    [JsonPropertyName("splitscreen")]
    public bool HasSplitScreen { get; set; }
    
    [JsonPropertyName("splitscreenonline")]
    public bool HasSplitScreenOnline { get; set; }
    
    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}