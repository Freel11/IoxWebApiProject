using Microsoft.AspNetCore.Mvc;
using MediatR;
using Iox.Api.Models;
using Iox.Api.Commands;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RenewLicenseController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMediator _mediator;

    public RenewLicenseController(ApiContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<ActionResult<Vehicle>> RenewLicense(Vehicle vehicle)
    {
        var command = new RenewLicenseCommand(vehicle);
        var request = await _mediator.Send(command);
        return request == null ? NotFound() : Ok(request);
    }

}