namespace PlayNextServer.Models.Database_v1;

public class CompanyStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Checksum { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}