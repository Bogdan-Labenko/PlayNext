using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class GameEngine 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonElement("logo")]
    public GameEngineLogo Logo { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("platforms")]
    public IList<Platform> Platforms { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}