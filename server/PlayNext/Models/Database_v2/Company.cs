using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class Company 
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("country")]
    public int CountryCode { get; set; }
    
    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonElement("developed")]
    public IList<int> DevelopedGames { get; set; }
    
    [BsonElement("logo")]
    public CompanyLogo Logo { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("parent")]
    public Company ParentCompany { get; set; }
    
    [BsonElement("published")]
    public IList<int> PublishedGames { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("start_date")]
    public DateTime StartDate { get; set; }
    
    [BsonElement("status")]
    public CompanyStatus Status { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
}