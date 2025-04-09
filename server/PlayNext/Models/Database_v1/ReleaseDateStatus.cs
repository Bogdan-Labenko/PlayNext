using System.Text.Json.Serialization;

namespace PlayNextServer.Models;

public class ReleaseDateStatus
{
    public int Id { get; set; }

    public string? Checksum { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
}