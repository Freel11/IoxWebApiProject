using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Iox.Api.Models;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GetVehicleListController : ControllerBase
{
    private readonly ApiContext _context;

    public GetVehicleListController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetAccount(long id)
    {
        IEnumerable<Vehicle> allVehicles = await _context.Vehicles.Where(x => x.Color == "red").ToListAsync();

        if (allVehicles == null)
        {
            return NotFound();
        }

        return allVehicles;
    }

}