using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class Screenshot
{
    public int Id { get; set; }

    public bool? AlphaChannel { get; set; }

    public bool? Animated { get; set; }

    public string? Checksum { get; set; }
    
    public int? GameId { get; set; }
    public Game? Game { get; set; }

    public int? Height { get; set; }

    public string ImageId { get; set; }

    public int? Width { get; set; }
}