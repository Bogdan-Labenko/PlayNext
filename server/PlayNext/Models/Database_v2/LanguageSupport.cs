using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class LanguageSupport 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("game")]
    public Game Game { get; set; }
    
    [BsonElement("language")]
    public Language Language { get; set; }
    
    [BsonElement("language_support_type")]
    public LanguageSupportType LanguageSupportType { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}