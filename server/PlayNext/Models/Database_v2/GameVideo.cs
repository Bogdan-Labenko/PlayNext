using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class GameVideo 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("video_id")]
    public string VideoId { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
}