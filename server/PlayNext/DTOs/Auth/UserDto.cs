using PlayNextServer.Models.Auth;

namespace PlayNextServer.DTOs.Auth;

public class UserDto
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}