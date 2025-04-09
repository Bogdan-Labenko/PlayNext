using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class GameVideo
{
    public int Id { get; set; }

    public string? Checksum { get; set; }

    public string? Name { get; set; }

    public int? GameId { get; set; }
    public Game? Game { get; set; }

    public string? VideoId { get; set; }
}