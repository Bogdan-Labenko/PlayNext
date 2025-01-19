using System.Text.Json.Serialization;

namespace SteamParse.DTOs;

public class App
{
    [JsonPropertyName("appid")]
    public int AppId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("last_modified")]
    public ulong LastModified { get; set; }
    [JsonPropertyName("price_change_number")]
    public int PriceChangeNumber { get; set; }
}