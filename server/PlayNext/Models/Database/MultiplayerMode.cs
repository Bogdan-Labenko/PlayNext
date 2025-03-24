using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class MultiplayerMode
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("campaigncoop")]
    public bool? CampaignCoop { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("dropin")]
    public bool? DropIn { get; set; }

    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }

    [JsonPropertyName("lancoop")]
    public bool? LanCoop { get; set; }

    [JsonPropertyName("offlinecoop")]
    public bool? OfflineCoop { get; set; }

    [JsonPropertyName("offlinecoopmax")]
    public int? OfflineCoopMax { get; set; }

    [JsonPropertyName("offlinemax")]
    public int? OfflineMax { get; set; }

    [JsonPropertyName("onlinecoop")]
    public bool? OnlineCoop { get; set; }

    [JsonPropertyName("onlinecoopmax")]
    public int? OnlineCoopMax { get; set; }

    [JsonPropertyName("onlinemax")]
    public int? OnlineMax { get; set; }

    [JsonPropertyName("platform")]
    public int? PlatformId { get; set; }
    
    public Platform? Platform { get; set; }

    [JsonPropertyName("splitscreen")]
    public bool? SplitScreen { get; set; }

    [JsonPropertyName("splitscreenonline")]
    public bool? SplitScreenOnline { get; set; }
}