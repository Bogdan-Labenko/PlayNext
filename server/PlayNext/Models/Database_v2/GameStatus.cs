using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class GameStatus 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("status")]
    public string Status { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
}