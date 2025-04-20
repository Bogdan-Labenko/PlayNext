using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class ReleaseDate
{ 
    public int Id { get; set; }
    
    public DateTime? Date { get; set; }
    
    public int? GameId { get; set; }
    public Game? Game { get; set; }
    
    public int? PlatformId { get; set; }
    public Platform? Platform { get; set; }
    
    public int? ReleaseDateStatusId { get; set; }
    public ReleaseDateStatus? Status { get; set; }
    
    public string Checksum { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}