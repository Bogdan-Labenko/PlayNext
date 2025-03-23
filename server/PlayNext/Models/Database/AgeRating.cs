using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class AgeRating
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("category")]
    public AgeRatingType? Category { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("rating")]
    public AgeRatingEnum? Rating { get; set; }
    
    [JsonPropertyName("rating_cover_url")]
    public string? RatingCoverUrl { get; set; }
}