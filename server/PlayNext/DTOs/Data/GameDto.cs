using System.Text.Json.Serialization;
using PlayNextServer.Models.Database_v1;

namespace PlayNextServer.DTOs.Data;

public class GameDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("aggregated_rating")]
    public double AggregatedRating { get; set; }

    [JsonPropertyName("aggregated_rating_count")]
    public int AggregatedRatingCount { get; set; }

    [JsonPropertyName("alternative_names")]
    public IList<int> AlternativeNamesId { get; set; }

    [JsonPropertyName("artworks")]
    public IList<int>? ArtworksId { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    [JsonPropertyName("cover")]
    public int? CoverId { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("dlcs")]
    public IList<int>? DlcsId { get; set; }

    [JsonPropertyName("first_release_date")]
    public DateTime? FirstReleaseDate { get; set; }

    [JsonPropertyName("game_franchises")]
    public IList<int>? GameFranchisesId { get; set; }

    [JsonPropertyName("game_engines")]
    public IList<int>? GameEnginesId { get; set; }

    [JsonPropertyName("game_modes")]
    public IList<int>? GameModesId { get; set; }
    
    [JsonPropertyName("game_status")]
    public int? GameStatusId { get; set; }
    
    [JsonPropertyName("status")]
    public GameStatusEnum GameStatusEnum { get; set; }
    
    [JsonPropertyName("game_type")]
    public int GameTypeId { get; set; }

    [JsonPropertyName("genres")]
    public IList<int>? GenresId { get; set; }

    [JsonPropertyName("involved_companies")]
    public IList<int>? InvolvedCompaniesId { get; set; }

    [JsonPropertyName("keywords")]
    public IList<int>? KeywordsId { get; set; }

    [JsonPropertyName("language_supports")]
    public IList<int>? LanguageSupportsId { get; set; }

    [JsonPropertyName("multiplayer_modes")]
    public IList<int>? MultiplayerModesId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("parent_game")]
    public int ParentGameId { get; set; }

    [JsonPropertyName("platforms")]
    public IList<int>? PlatformsId { get; set; }

    [JsonPropertyName("player_perspectives")]
    public IList<int>? PlayerPerspectivesId { get; set; }

    [JsonPropertyName("release_dates")]
    public IList<int>? ReleaseDatesId { get; set; }

    [JsonPropertyName("screenshots")]
    public IList<int>? ScreenshotsId { get; set; }
    
    [JsonPropertyName("similar_games")]
    public IList<int>? SimilarGames { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("storyline")]
    public string? Storyline { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("tags")]
    public IList<int>? Tags { get; set; }

    [JsonPropertyName("themes")]
    public IList<int>? ThemesId { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("videos")]
    public IList<int>? VideosId { get; set; }
}