using Microsoft.AspNetCore.Mvc;
using MediatR;
using Iox.Api.Models;
using Iox.Api.Commands;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AddVehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddVehicleController(ApiContext context, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> CreateNewVehicle(Vehicle vehicle)
    {
        var command = new CreateNewVehicleCommand(vehicle);
        var result = await _mediator.Send(command);
        return result == null ? NotFound() : Ok(result);
    }
}