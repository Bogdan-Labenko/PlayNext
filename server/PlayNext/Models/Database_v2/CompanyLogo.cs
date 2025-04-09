using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class CompanyLogo 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("alpha_channel")]
    public bool AlphaChanel { get; set; }
    
    [BsonElement("animated")]
    public bool Animated { get; set; }
    
    [BsonElement("height")]
    public int Height { get; set; }
    
    [BsonElement("width")]
    public int Width { get; set; }
    
    [BsonElement("image_id")]
    public string ImageId { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
}