using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class InvolvedCompany 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("company")]
    public Company Company { get; set; }
    
    [BsonElement("create_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [BsonElement("developer")]
    public bool IsDeveloper { get; set; }
    
    [BsonElement("game")]
    public Game Game { get; set; }
    
    [BsonElement("porting")]
    public bool IsPorting { get; set; }
    
    [BsonElement("publisher")]
    public bool IsPublisher { get; set; }
    
    [BsonElement("supporting")]
    public bool IsSupporting { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
}