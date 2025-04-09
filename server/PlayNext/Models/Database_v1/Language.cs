using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Language
{
    public int Id { get; set; }
    
    public string? Checksum { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? Name { get; set; }
    
    public string? Locale { get; set; }
    
    public string? NativeName { get; set; }
}