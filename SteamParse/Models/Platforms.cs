using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class Platforms
{
    public int Id { get; set; }
    [JsonPropertyName("windows")]
    public bool Windows { get; set; }

    [JsonPropertyName("mac")]
    public bool Mac { get; set; }

    [JsonPropertyName("linux")]
    public bool Linux { get; set; }
}
