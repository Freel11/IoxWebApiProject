using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Iox.Api.Models;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AddVehicleController : ControllerBase
{
    private readonly ApiContext _context;

    public AddVehicleController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(long id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return vehicle;
    }

    [HttpPost]

    public async Task<ActionResult<Account>> CreateNewVehicle(Vehicle vehicle)
    {
        var userAccount = await _context.Accounts.FindAsync(vehicle.AccountForeignKey);

        if (userAccount == null)
        {
            return NotFound();
        }

        if (_context.Vehicles.Any(o => o.VIN == vehicle.VIN))
        {
            return NotFound();
        }

        var newVehicle = new Vehicle
        {
            VIN = vehicle.VIN,
            LicenseNumber = vehicle.LicenseNumber,
            RegistrationPlate = vehicle.RegistrationPlate,
            LicenseExpiry = vehicle.LicenseExpiry,
            Model = vehicle.Model,
            Color = vehicle.Color,
            Account = userAccount,
            AccountForeignKey = userAccount.Id
        };

        _context.Vehicles.Add(newVehicle);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetVehicle),
            new { id = newVehicle.VIN },
            newVehicle
        );
    }
}