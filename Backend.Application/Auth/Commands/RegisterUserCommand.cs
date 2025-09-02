using MediatR;

namespace Backend.Application.Auth.Commands;

public class RegisterUserCommand : IRequest<string>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
}
