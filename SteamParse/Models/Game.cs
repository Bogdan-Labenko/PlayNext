using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SteamParse.Models;

public class Game
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("steam_appid")]
    [Key]
    public int SteamId { get; set; }

    [JsonPropertyName("required_age")]
    public int RequiredAge { get; set; }

    [JsonPropertyName("is_free")]
    public bool IsFree { get; set; }

    [JsonPropertyName("controller_support")]
    public string ControllerSupport { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("supported_languages")]
    public string SupportedLanguages { get; set; }

    [JsonPropertyName("header_image")]
    public string HeaderImage { get; set; }

    [JsonPropertyName("website")]
    public string Website { get; set; }

    [JsonPropertyName("developers")]
    public string[] Developers { get; set; }

    [JsonPropertyName("publishers")]
    public string[] Publishers { get; set; }

    [JsonPropertyName("price_overview")]
    public PriceOverview PriceOverview { get; set; }

    [JsonPropertyName("categories")]
    public Category[] Categories { get; set; }

    [JsonPropertyName("genres")]
    public Genre[] Genres { get; set; }

    [JsonPropertyName("release_date")]
    public ReleaseDate ReleaseDate { get; set; }

    [JsonPropertyName("metacritic")]
    public Metacritic Metacritic { get; set; }

    [JsonPropertyName("platforms")]
    public Platforms Platforms { get; set; }

    [JsonPropertyName("dlc")]
    public int[] Dlcs { get; set; }
}