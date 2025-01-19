using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class Genre
{
    public int Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
