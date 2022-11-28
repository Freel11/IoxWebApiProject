using Microsoft.AspNetCore.Mvc;
using PagedList;
using MediatR;
using Iox.Api.Models;
using Iox.Api.Queries;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GetVehicleListController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMediator _mediator;

    public GetVehicleListController(ApiContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<Vehicle>>> Get(
        long? vin, 
        string? licenseNumber,
        string? registrationPlate,
        DateTime? licenseExpiry,
        string? model, 
        string? color,
        long? account,
        int pageNo = 0,
        int pageSize = 0)
    {
        var query = new GetVehicleListQuery(
            vin,
            licenseNumber,
            registrationPlate,
            licenseExpiry,
            model,
            color,
            account,
            pageNo,
            pageSize);

        var result = await _mediator.Send(query);
        return result == null ? NotFound() : Ok(result);
    }

}