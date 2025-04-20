using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class InvolvedCompany
{
    public int Id { get; set; }
    
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public string? Checksum { get; set; }
    
    public bool IsDeveloper { get; set; }
    
    public int? GameId { get; set; }
    public Game? Game { get; set; }
    
    public bool IsPorting { get; set; }
    
    public bool IsPublisher { get; set; }
    
    public bool IsSupporting { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}