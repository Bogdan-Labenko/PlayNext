using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Platform
{
    public int Id { get; set; }
    
    public string? Abbreviation { get; set; }
    
    public string? AlternativeName { get; set; }
    
    public IList<Game>? Games { get; set; }
    
    public int? Generation { get; set; }
    
    public string Name { get; set; }
    
    public int? PlatformLogoId { get; set; }
    public PlatformLogo? PlatformLogo { get; set; }
    
    public int? PlatformTypeId { get; set; }
    public PlatformType? PlatformType { get; set; }
    
    public string Slug { get; set; }
    
    public string? Summary { get; set; }
    
    public string Checksum { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}