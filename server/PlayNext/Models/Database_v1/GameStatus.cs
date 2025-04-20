namespace PlayNextServer.Models.Database_v1;

public class GameStatus
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Checksum { get; set; }
}