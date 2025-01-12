using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class PcRequirements
{
    public int Id { get; set; }
    [JsonPropertyName("minimum")]
    public string? Minimum { get; set; }
    
    [JsonPropertyName("recommended")]
    public string? Recommended { get; set; }
}