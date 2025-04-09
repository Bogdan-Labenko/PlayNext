namespace PlayNextServer.Models.Database_v1;

public class GameGameMode
{
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    public int GameModeId { get; set; }
    public GameMode GameMode { get; set; }
}