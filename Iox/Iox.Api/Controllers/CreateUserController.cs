using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Iox.Api.Models;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CreateUserController : ControllerBase
{
    private readonly ApiContext _context;

    public CreateUserController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateNewUser(User user)
    {
        var newUser = new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Account = new Account {
                Id = 1,
                Balance = user.Account.Balance
            }
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUser),
            new { id = newUser.Id },
            newUser
        );
    }
}