using System.Runtime.Intrinsics.X86;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class Franchise
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("games")]
    public IList<Game> Games { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}