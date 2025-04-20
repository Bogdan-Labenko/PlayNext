namespace PlayNextServer.Models.Database_v1;

public class GameGameEngines
{
    public int GameId { get; set; }
    public Game Game { get; set; }

    public int GameEngineId { get; set; }
    public GameEngine GameEngine { get; set; }
}