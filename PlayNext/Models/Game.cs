using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SteamParse.Converters;
using SteamParse.Models;

public class Game
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("steam_appid")]
    [Key]
    public int SteamId { get; set; }

    [JsonPropertyName("required_age")]
    [JsonConverter(typeof(RequiredAgeConverter))]
    public string RequiredAge { get; set; }

    [JsonPropertyName("is_free")]
    public bool IsFree { get; set; }

    [JsonPropertyName("controller_support")]
    public string? ControllerSupport { get; set; }

    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; set; }

    [JsonPropertyName("supported_languages")]
    public string? SupportedLanguages { get; set; }

    [JsonPropertyName("header_image")]
    public string? HeaderImage { get; set; }
    
    [JsonPropertyName("capsule_image")]
    public string? CapsuleImage { get; set; }
    
    [JsonPropertyName("capsule_imagev5")]
    public string? CapsuleImageSmall { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    public int? PcRequirementsId { get; set; }
    
    [JsonPropertyName("pc_requirements")]
    [JsonConverter(typeof(EmptyArrayToNullConverter<PcRequirements>))]
    public PcRequirements? PcRequirements { get; set; }
    
    [JsonPropertyName("legal_notice")]
    public string? LegalNotice { get; set; }
         
    [JsonPropertyName("developers")]
    public string[]? Developers { get; set; }

    [JsonPropertyName("publishers")]
    public string[]? Publishers { get; set; }

    [JsonPropertyName("categories")]
    public IList<Category>? Categories { get; set; }

    [JsonPropertyName("genres")]
    public IList<Genre>? Genres { get; set; }

    [JsonPropertyName("release_date")]
    public ReleaseDate ReleaseDate { get; set; }

    [JsonPropertyName("metacritic")]
    public Metacritic? Metacritic { get; set; }
    
    [JsonPropertyName("screenshots")]
    public IList<Screenshot>? Screenshots { get; set; }
}