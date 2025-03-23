using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.DTOs.Auth;
using PlayNextServer.Models.Auth;
using PlayNextServer.Services;

namespace PlayNextServer.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private AppDbContext _dbContext;
    private IJwtTokenService _tokenService;
    
    public AuthController(AppDbContext context, IJwtTokenService tokenService)
    {
        _dbContext = context;
        _tokenService = tokenService;
    }
    
    [HttpPost]
    [Route("signup")]
    public async Task<ActionResult<SignUpResponse>> SignUp(SignUpRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) 
            || string.IsNullOrWhiteSpace(request.Nickname) 
            || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest();
        }

        var isUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (isUser is not null)
        {
            return Conflict(new { message = ErrorCodes.UserAlreadyExist });
        }

        var user = await _dbContext.Users.AddAsync(new User
        {
            Email = request.Email,
            Nickname = request.Nickname,
            PasswordHash = PasswordHelper.HashPassword(request.Password),
            Role = request.Role,
            CreatedAt = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow
        });

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            return Problem("Database error", statusCode: 500);
        }

        var token = await _tokenService.GenerateJwtTokenAsync(request.Email, request.Role);
        
        return Ok(new SignUpResponse()
        {
            User = new UserDto
            {
                Email = request.Email,
                Nickname = request.Nickname,
                Role = request.Role,
                Id = user.Entity.Id
            },
            AccessToken = token
        });
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LogInResponse>> LogIn(LogInRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) 
            || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest();
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user is null || !PasswordHelper.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = ErrorCodes.WrongLoginOrPassword });
        }

        var token = await _tokenService.GenerateJwtTokenAsync(request.Email, user.Role);
        
        return Ok(new LogInResponse()
        {
            User = new UserDto
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Role = user.Role,
                Email = user.Email
            },
            AccessToken = token
        });
    }
}