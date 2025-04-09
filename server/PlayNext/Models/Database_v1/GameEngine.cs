namespace PlayNextServer.Models.Database_v1;

public class GameEngine
{
    public int Id { get; set; }

    public string? Checksum { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public int? LogoId { get; set; }
    public GameEngineLogo? Logo { get; set; }
    
    public IList<Game> Games { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}