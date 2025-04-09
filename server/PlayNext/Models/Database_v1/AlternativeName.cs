using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class AlternativeName
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Comment { get; set; }
    
    public int? GameId { get; set; }
    
    public Game? Game { get; set; }
    
    public string Checksum { get; set; }
}