namespace PlayNextServer.DTOs.Auth;

public class SignUpResponse
{
    public UserDto User { get; set; }
    public string AccessToken { get; set; }
}