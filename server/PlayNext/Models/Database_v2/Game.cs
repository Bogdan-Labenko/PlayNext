using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayNextServer.Models.Database_v2;

public class Game
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("aggregated_rating")]
    public double AggregatedRating { get; set; }
    
    [BsonElement("aggregated_rating_count")]
    public int AggregatedRatingCount { get; set; }
    
    [BsonElement("alternative_names")]
    public IList<AlternativeName> AlternativeNames { get; set; }
    
    [BsonElement("artworks")]
    public IList<Artwork> Artworks { get; set; }
    
    [BsonElement("checksum")]
    public string Checksum { get; set; }
    
    [BsonElement("cover")]
    public Cover Cover { get; set; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [BsonElement("dlcs")]
    public Game Dlcs { get; set; }
    
    [BsonElement("first_release_date")]
    public DateTime FirstReleaseDate { get; set; }
    
    [BsonElement("franchise")]
    public Franchise Franchise { get; set; }
    
    [BsonElement("game_engines")]
    public GameEngine GameEngines { get; set; }
    
    [BsonElement("game_modes")]
    public IList<GameMode> GameModes { get; set; }
    
    [BsonElement("game_status")]
    public GameStatus GameStatus { get; set; }
    
    [BsonElement("game_type")]
    public GameType GameType { get; set; }
    
    [BsonElement("genres")]
    public IList<Genre> Genres { get; set; }
    
    [BsonElement("involved_companies")]
    public IList<InvolvedCompany> InvolvedCompanies { get; set; }
	
    [BsonElement("keywords")]
    public IList<Keyword> Keywords { get; set; }
    
    [BsonElement("language_supports")]
    public IList<LanguageSupport> LanguageSupports { get; set; }
    
    [BsonElement("multiplayer_modes")]
    public IList<MultiplayerMode> MultiplayerModes { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("parent_game")]
    public Game ParentGame { get; set; }
    
    [BsonElement("platforms")]
    public IList<Platform> Platforms { get; set; }
    
    [BsonElement("player_perspectives")]
    public IList<PlayerPerspective> PlayerPerspectives { get; set; }
    
    [BsonElement("release_dates")]
    public IList<ReleaseDate> ReleaseDates { get; set; }
    
    [BsonElement("screenshots")]
    public IList<Screenshot> Screenshots { get; set; }
    
    [BsonElement("similar_games")]
    public IList<Game> SimilarGames { get; set; }
    
    [BsonElement("slug")]
    public string Slug { get; set; }
    
    [BsonElement("storyline")]
    public string Storyline { get; set; }
    
    [BsonElement("summary")]
    public string Summary { get; set; }
    
    [BsonElement("tags")]
    public IList<int> Tags { get; set; }
    
    [BsonElement("themes")]
    public IList<Theme> Themes { get; set; }
    
    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [BsonElement("videos")]
    public IList<GameVideo> Videos { get; set; }
    
    
}