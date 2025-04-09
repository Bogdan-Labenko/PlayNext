using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Game
{
    public int Id { get; set; }
    public double AggregatedRating { get; set; }
    public int AggregatedRatingCount { get; set; }
    public IList<AlternativeName>? AlternativeNames { get; set; }
    public IList<Artwork>? Artworks { get; set; }
    public string? Checksum { get; set; }
    public int? CoverId { get; set; }
    public Cover? Cover { get; set; }
    public DateTime? CreatedAt { get; set; }
    
    public int? BaseGameId { get; set; }
    public Game? BaseGame { get; set; }
    public IList<Game>? Dlcs { get; set; }
    public DateTime? FirstReleaseDate { get; set; }
    public IList<Franchise>? Franchises { get; set; }
    public IList<GameEngine> GameEngines { get; set; }
    public IList<GameMode>? GameModes { get; set; }
    public int? GameStatusId { get; set; }
    public GameStatus? GameStatus { get; set; }
    public GameStatusEnum GameStatusEnum { get; set; }
    public int? GameTypeId { get; set; }
    public GameType? GameType { get; set; }
    public IList<Genre>? Genres { get; set; }
    public IList<InvolvedCompany>? InvolvedCompanies { get; set; }
    public IList<Keyword>? Keywords { get; set; }
    public IList<LanguageSupport>? LanguageSupports { get; set; }
    public IList<MultiplayerMode>? MultiplayerModes { get; set; }
    public string? Name { get; set; }
    
    public IList<Platform>? Platforms { get; set; }
    public IList<PlayerPerspective>? PlayerPerspectives { get; set; }
    public IList<ReleaseDate>? ReleaseDates { get; set; }
    public IList<Screenshot>? Screenshots { get; set; }
    public string? Slug { get; set; }
    public string? Storyline { get; set; }
    public string? Summary { get; set; }
    public IList<int>? Tags { get; set; }
    public IList<Theme>? Themes { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public IList<GameVideo>? Videos { get; set; }
}