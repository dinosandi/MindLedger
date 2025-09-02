// Backend.Application/Auth/Commands/GoogleSignInCommand.cs
using MediatR;

namespace Backend.Application.Auth.Commands
{
    public class GoogleSignInCommand : IRequest<(string token, object user)>
    {
        public string IdToken { get; set; } = string.Empty;
    }
}
