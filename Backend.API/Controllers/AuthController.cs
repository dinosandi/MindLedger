using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<User> userManager,
        IEmailService emailService,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { _configuration["Authentication:Google:ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            
            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = payload.Email,
                    UserName = payload.Email,
                    Name = payload.Name,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _emailService.SendWelcomeEmailAsync(user.Email, user.Name);
                }
            }

            // Generate JWT token here
            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Invalid Google token" });
        }
    }

    private string GenerateJwtToken(User user)
    {
        // Implement JWT token generation
        // This is just a placeholder
        return "jwt_token";
    }
}
}
