using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class Category
{
    public int Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
