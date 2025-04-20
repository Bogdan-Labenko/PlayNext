using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Franchise
{
    public int Id { get; set; }
    public string? Checksum { get; set; }
    public IList<Game>? Games { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}