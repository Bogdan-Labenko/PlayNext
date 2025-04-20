using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class MultiplayerMode 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("campaigncoop")]
    public bool HasCampaignCoop { get; set; }
    
    [BsonElement("dropin")]
    public bool HasDropIn { get; set; }
    
    [BsonElement("game")]
    public Game Game { get; set; }
    
    [BsonElement("lancoop")]
    public bool HasLanCoop { get; set; }
    
    [BsonElement("offlinecoop")]
    public bool HasOfflineCoop { get; set; }
    
    [BsonElement("offlinecoopmax")]
    public bool HasOfflineCoopMax { get; set; }
    
    [BsonElement("offlinemax")]
    public int OfflineMax { get; set; }
    
    [BsonElement("onlinecoop")]
    public bool HasOnlineCoop { get; set; }
    
    [BsonElement("onlinecoopmax")]
    public int OnlineCoopMax { get; set; }
    
    [BsonElement("onlinemax")]
    public int OnlineMax { get; set; }
    
    [BsonElement("platform")]
    public Platform Platform { get; set; }
    
    [BsonElement("splitscreen")]
    public bool HasSplitScreen { get; set; }
    
    [BsonElement("splitscreenonline")]
    public bool HasSplitScreenOnline { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}