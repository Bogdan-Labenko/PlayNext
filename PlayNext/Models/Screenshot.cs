using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class Screenshot
{
    public int Id { get; set; }
    
    [JsonPropertyName("path_thumbnail")]
    public string Thumbnail { get; set; } 
    
    [JsonPropertyName("path_full")]
    public string Full { get; set; }
}