using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class ReleaseDate
{
    public int Id { get; set; }
    [JsonPropertyName("coming_soon")]
    public bool ComingSoon { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }
}
