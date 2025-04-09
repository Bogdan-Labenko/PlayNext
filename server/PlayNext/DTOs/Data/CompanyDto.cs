using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs.Data;

public class CompanyDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("country")]
    public int CountryCode { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("developed")]
    public IList<int> DevelopedGames { get; set; } // Массив ID игр, а не объекты

    [JsonPropertyName("logo")]
    public int LogoId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("parent")]
    public int? ParentCompanyId { get; set; } // Используем ID родительской компании

    [JsonPropertyName("published")]
    public IList<int> PublishedGames { get; set; } // Массив ID игр, а не объекты

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("status")]
    public int CompanyStatusId { get; set; }

    [JsonPropertyName("checksum")]
    public string Checksum { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}