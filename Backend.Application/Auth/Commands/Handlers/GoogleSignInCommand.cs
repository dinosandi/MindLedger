using MediatR;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Google.Apis.Auth;

namespace Backend.Application.Auth.Commands.Handlers;
public class GoogleSignInHandler : IRequestHandler<GoogleSignInCommand, (string token, object user)>
{
    private readonly IConfiguration _config;

    public GoogleSignInHandler(IConfiguration config)
    {
        _config = config;
    }

    public async Task<(string token, object user)> Handle(GoogleSignInCommand request, CancellationToken cancellationToken)
    {
        var payload = await Google.Apis.Auth.GoogleJsonWebSignature.ValidateAsync(request.IdToken);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["TokenKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, payload.Email),
                new Claim(ClaimTypes.Name, payload.Name),
                new Claim("GoogleId", payload.Subject)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return (tokenHandler.WriteToken(token), new { payload.Email, payload.Name });
    }
}
