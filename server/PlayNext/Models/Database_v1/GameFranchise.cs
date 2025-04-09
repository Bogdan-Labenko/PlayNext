namespace PlayNextServer.Models.Database_v1;

public class GameFranchise
{
    public int GameId { get; set; }
    public Game Game { get; set; }

    public int FranchiseId { get; set; }
    public Franchise Franchise { get; set; }
}