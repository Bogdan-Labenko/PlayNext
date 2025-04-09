using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class LanguageSupport
{
    public int Id { get; set; }
    public string? Checksum { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? GameId { get; set; }
    public Game? Game { get; set; }
    public int? LanguageId { get; set; }
    public Language? Language { get; set; }
    public int? LanguageSupportTypeId { get; set; }
    public LanguageSupportType? LanguageSupportType { get; set; }
}