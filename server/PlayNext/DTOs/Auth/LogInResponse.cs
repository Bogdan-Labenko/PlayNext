namespace PlayNextServer.DTOs.Auth;

public class LogInResponse
{
    public UserDto User { get; set; }
    public string AccessToken { get; set; }
}