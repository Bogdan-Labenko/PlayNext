using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class MultiplayerMode
{
    public int Id { get; set; }
    
    public bool HasCampaignCoop { get; set; }
    
    public bool HasDropIn { get; set; }
    
    public int? GameId { get; set; }
    public Game? Game { get; set; }
    
    public bool HasLanCoop { get; set; }
    
    public bool HasOfflineCoop { get; set; }
    
    public int OfflineCoopMax { get; set; }
    
    public int OfflineMax { get; set; }
    
    public bool HasOnlineCoop { get; set; }
    
    public int OnlineCoopMax { get; set; }
    
    public int OnlineMax { get; set; }
    
    public int? PlatformId { get; set; }
    public Platform? Platform { get; set; }
    
    public bool HasSplitScreen { get; set; }
    
    public bool HasSplitScreenOnline { get; set; }
    
    public string Checksum { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}