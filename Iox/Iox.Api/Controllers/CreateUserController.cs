using Microsoft.AspNetCore.Mvc;
using MediatR;
using Iox.Api.Models;
using Iox.Api.Commands;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CreateUserController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMediator _mediator;

    public CreateUserController(ApiContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateNewUser(User user)
    {
        var command = new CreateNewUserCommand(user);
        var request = await _mediator.Send(command);
        return Ok(request);
    }
}