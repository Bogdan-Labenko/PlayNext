using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNextServer.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Game
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("age_ratings")] public IList<int>? AgeRatingsId { get; set; }
    public IList<AgeRating>? AgeRatings { get; set; }

    [JsonPropertyName("aggregated_rating")]
    public double AggregatedRating { get; set; }

    [JsonPropertyName("aggregated_rating_count")]
    public int AggregatedRatingCount { get; set; }

    [JsonPropertyName("artworks")] public IList<int>? ArtworksId { get; set; }
    public IList<Artwork>? Artworks { get; set; }

    [JsonPropertyName("bundles")] public IList<int>? BundlesId { get; set; }
    public IList<Game>? Bundles { get; set; }

    [JsonPropertyName("category")] public Category? Category { get; set; }

    [JsonPropertyName("checksum")] public Guid? Checksum { get; set; }

    [JsonPropertyName("collections")] public IList<int>? CollectionsId { get; set; }
    public IList<Collection>? Collections { get; set; }

    [JsonPropertyName("cover")] public int CoverId { get; set; }
    public Cover? Cover { get; set; }

    [JsonPropertyName("dlcs")] public IList<int>? DlcsId { get; set; }
    public IList<Game>? Dlcs { get; set; }

    [JsonPropertyName("expanded_games")] public IList<int>? ExpandedGamesId { get; set; }
    public IList<Game>? ExpandedGames { get; set; }

    [JsonPropertyName("expansions")] public IList<int>? ExpansionsId { get; set; }
    public IList<Game>? Expansions { get; set; }

    [JsonPropertyName("first_release_date")]
    public DateTime? FirstReleaseDate { get; set; }

    [JsonPropertyName("forks")] public IList<int>? ForksId { get; set; }
    public IList<Game>? Forks { get; set; }

    [JsonPropertyName("franchises")] public IList<int>? FranchisesId { get; set; }
    public IList<Franchise>? Franchises { get; set; }

    [JsonPropertyName("game_engines")] public IList<int>? GameEnginesId { get; set; }
    public IList<GameEngine>? GameEngines { get; set; }

    [JsonPropertyName("game_modes")] public IList<int>? GameModesId { get; set; }
    public IList<GameMode>? GameModes { get; set; }

    [JsonPropertyName("genres")] public IList<int>? GenresId { get; set; }
    public IList<Genre>? Genres { get; set; }

    [JsonPropertyName("hypes")] public int Hypes { get; set; }

    [JsonPropertyName("involved_companies")]
    public IList<int>? InvolvedCompaniesId { get; set; }

    public IList<InvolvedCompany>? InvolvedCompanies { get; set; }

    [JsonPropertyName("keywords")] public IList<int>? KeywordsId { get; set; }
    public IList<Keyword>? Keywords { get; set; }

    [JsonPropertyName("language_supports")]
    public IList<int>? LanguageSupportsId { get; set; }

    public IList<LanguageSupport>? LanguageSupports { get; set; }

    [JsonPropertyName("multiplayer_modes")]
    public IList<int>? MultiplayerModesId { get; set; }

    public IList<MultiplayerMode>? MultiplayerModes { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("parent_game")] public int ParentGameId { get; set; }
    [NotMapped] public Game? ParentGame { get; set; }

    [JsonPropertyName("platforms")] public IList<int>? PlatformsId { get; set; }
    public IList<Platform>? Platforms { get; set; }

    [JsonPropertyName("player_perspectives")]
    public IList<int>? PlayerPerspectivesId { get; set; }

    public IList<PlayerPerspective>? PlayerPerspectives { get; set; }

    [JsonPropertyName("ports")] public IList<int>? PortsId { get; set; }
    public IList<Game>? Ports { get; set; }

    [JsonPropertyName("rating")] public double Rating { get; set; }

    [JsonPropertyName("rating_count")] public int RatingCount { get; set; }

    [JsonPropertyName("release_dates")] public IList<int>? ReleaseDatesId { get; set; }
    public IList<ReleaseDate>? ReleaseDates { get; set; }

    [JsonPropertyName("remakes")] public IList<int>? RemakesId { get; set; }
    public IList<Game>? Remakes { get; set; }

    [JsonPropertyName("remasters")] public IList<int>? RemastersId { get; set; }
    public IList<Game>? Remasters { get; set; }

    [JsonPropertyName("screenshots")] public IList<int>? ScreenshotsId { get; set; }
    public IList<Screenshot>? Screenshots { get; set; }

    [JsonPropertyName("similar_games")] public IList<int>? SimilarGamesId { get; set; }
    public IList<Game>? SimilarGames { get; set; }

    [JsonPropertyName("slug")] public string? Slug { get; set; }

    [JsonPropertyName("standalone_expansions")]
    public IList<int>? StandaloneExpansionsId { get; set; }

    public IList<Game>? StandaloneExpansions { get; set; }

    [JsonPropertyName("status")] public Status Status { get; set; }

    [JsonPropertyName("storyline")] public string? Storyline { get; set; }

    [JsonPropertyName("summary")] public string? Summary { get; set; }

    [JsonPropertyName("tags")] public IList<int>? Tags { get; set; }

    [JsonPropertyName("themes")] public IList<int>? ThemesId { get; set; }
    public IList<Theme>? Themes { get; set; }

    [JsonPropertyName("total_rating")] public double TotalRating { get; set; }

    [JsonPropertyName("total_rating_count")]
    public int TotalRatingCount { get; set; }

    [JsonPropertyName("updated_at")] public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("version_parent")] public int VersionParentId { get; set; }
    [NotMapped] public Game? VersionParent { get; set; }

    [JsonPropertyName("version_title")] public string? VersionTitle { get; set; }

    [JsonPropertyName("videos")] public IList<int>? VideosId { get; set; }
    public IList<GameVideo>? Videos { get; set; }

    [JsonPropertyName("websites")] public IList<int>? WebsitesId { get; set; }
    public IList<Website>? Websites { get; set; }
}
/*{
    public int Id { get; set; }

    [JsonPropertyName("age_ratings")]
    public IList<int>? AgeRatingsId { get; set; }

    [JsonPropertyName("aggregated_rating")]
    public double AggregatedRating { get; set; }

    [JsonPropertyName("aggregated_rating_count")]
    public int AggregatedRatingCount { get; set; }

    [JsonPropertyName("artworks")]
    public IList<int>? ArtworksId { get; set; }

    [JsonPropertyName("bundles")]
    public IList<int>? BundlesId { get; set; }

    [JsonPropertyName("category")]
    public Category? Category { get; set; }

    [JsonPropertyName("checksum")]
    public Guid? Checksum { get; set; }

    [JsonPropertyName("collections")]
    public IList<int>? CollectionsId { get; set; }

    [JsonPropertyName("cover")]
    public int CoverId { get; set; }

    [JsonPropertyName("dlcs")]
    public IList<int>? DlcsId { get; set; }

    [JsonPropertyName("expanded_games")]
    public IList<int>? ExpandedGamesId { get; set; }

    [JsonPropertyName("expansions")]
    public IList<int>? ExpansionsId { get; set; }

    [JsonPropertyName("external_games")]
    public IList<int>? ExternalGamesId { get; set; }

    [JsonPropertyName("first_release_date")]
    public DateTime? FirstReleaseDate { get; set; }

    [JsonPropertyName("forks")]
    public IList<int>? ForksId { get; set; }

    [JsonPropertyName("franchises")]
    public IList<int>? FranchisesId { get; set; }

    [JsonPropertyName("game_engines")]
    public IList<int>? GameEnginesId { get; set; }

    [JsonPropertyName("game_modes")]
    public IList<int>? GameModesId { get; set; }

    [JsonPropertyName("genres")]
    public IList<int>? GenresId { get; set; }

    [JsonPropertyName("hypes")]
    public int Hypes { get; set; }

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

    [JsonPropertyName("ports")]
    public IList<int>? PortsId { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("rating_count")]
    public int RatingCount { get; set; }

    [JsonPropertyName("release_dates")]
    public IList<int>? ReleaseDatesId { get; set; }

    [JsonPropertyName("remakes")]
    public IList<int>? RemakesId { get; set; }

    [JsonPropertyName("remasters")]
    public IList<int>? RemastersId { get; set; }

    [JsonPropertyName("screenshots")]
    public IList<int>? ScreenshotsId { get; set; }

    [JsonPropertyName("similar_games")]
    public IList<int>? SimilarGamesId { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("standalone_expansions")]
    public IList<int>? StandaloneExpansionsId { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("storyline")]
    public string? Storyline { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("tags")]
    public IList<int>? Tags { get; set; }

    [JsonPropertyName("themes")]
    public IList<int>? ThemesId { get; set; }

    [JsonPropertyName("total_rating")]
    public double TotalRating { get; set; }

    [JsonPropertyName("total_rating_count")]
    public int TotalRatingCount { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("version_parent")]
    public int VersionParentId { get; set; }

    [JsonPropertyName("version_title")]
    public string? VersionTitle { get; set; }

    [JsonPropertyName("videos")]
    public IList<int>? VideosId { get; set; }

    [JsonPropertyName("websites")]
    public IList<int>? WebsitesId { get; set; }
}*/