using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class Website
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("category")]
    public WebsiteType? Category { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("game")]
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }

    [JsonPropertyName("trusted")]
    public bool? Trusted { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}