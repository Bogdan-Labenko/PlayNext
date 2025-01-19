using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class GameInfo
{
    [JsonPropertyName("appid")]
    [Key]
    public int AppId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("last_modified")]
    public ulong LastModified { get; set; }

    [JsonPropertyName("price_change_number")]
    public int PriceChangeNumber { get; set; }
}