using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class Platform
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("abbreviation")]
    public string Abbreviation { get; set; }
    
    [BsonElement("alternative_name")]
    public string AlternativeName { get; set; }
    
    [BsonElement("generation")]
    public int Generation { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("platform_family")]
    public PlatformFamily PlatformFamily { get; set; }
    
    [BsonElement("platform_logo")]
    public PlatformLogo PlatformLogo { get; set; }
    
    [BsonElement("platform_type")]
    public PlatformType PlatformType { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("summary")]
    public string Summary { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}