namespace PlayNextServer.Models.Auth;

public class User
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public Role Role { get; set; }
    public DateTime LastLogin { get; set; }
}