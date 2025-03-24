using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlayNextServer.Models.Auth;

namespace PlayNextServer.DTOs.Auth;

public class SignUpRequest
{
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}