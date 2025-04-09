using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class PlatformFamily 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
}