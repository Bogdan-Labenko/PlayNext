using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlayNextServer.Models.Database_v1;

public class GameType
{
    public int Id { get; set; }
    
    public string Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Checksum { get; set; }
}