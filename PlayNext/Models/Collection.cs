using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class Collection
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }
    
    [JsonPropertyName("games")]
    public IList<int>? GamesId { get; set; }
    
    public ICollection<Game>? Games { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    
    [JsonPropertyName("type")]
    public int? TypeId { get; set; }
    
    public CollectionType? Type { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}