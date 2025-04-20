using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class ReleaseDate 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("date")]
    public DateTime Date { get; set; }
    
    [BsonElement("date_format")]
    public DateTime DateFormat { get; set; }
    
    [BsonElement("game")]
    public Game Game { get; set; }
    
    [BsonElement("platform")]
    public Platform Platform { get; set; }
    
    [BsonElement("status")]
    public ReleaseDateStatus Status { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}