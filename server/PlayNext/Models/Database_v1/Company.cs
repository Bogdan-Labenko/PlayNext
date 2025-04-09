using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Company
{
    public int Id { get; set; }
    public int CountryCode { get; set; }
    public string Description { get; set; }
    public IList<Game> DevelopedGames { get; set; } // Навигационное свойство
    
    public int LogoId { get; set; }
    public CompanyLogo Logo { get; set; }
    public string Name { get; set; }
    
    public int? ParentCompanyId { get; set; }
    public Company? ParentCompany { get; set; } // Навигационное свойство
    
    public IList<Game>? PublishedGames { get; set; } // Навигационное свойство
    public string Slug { get; set; }
    public DateTime StartDate { get; set; }
    
    public int CompanyStatusId { get; set; }
    public CompanyStatus Status { get; set; }
    public string Checksum { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}