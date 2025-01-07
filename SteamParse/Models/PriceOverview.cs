using System.Text.Json.Serialization;

namespace SteamParse.Models;

public class PriceOverview
{
    public int Id { get; set; }
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("initial")]
    public int Initial { get; set; }

    [JsonPropertyName("final")]
    public int Final { get; set; }

    [JsonPropertyName("discount_percent")]
    public int DiscountPercent { get; set; }
}
