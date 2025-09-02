using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Auth.Commands;

namespace Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login-google")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleSignInCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }
}
