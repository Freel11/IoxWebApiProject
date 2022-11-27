using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Iox.Api.Models;

namespace Iox.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DepositController : ControllerBase
{
    private readonly ApiContext _context;

    public DepositController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(long id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account == null)
        {
            return NotFound();
        }

        return account;
    }

    [HttpPost]
    public async Task<ActionResult<Account>> DepositAmmount(Account request)
    {
        var account = await _context.Accounts.FindAsync(request.Id);

        if (account == null)
        {
            return NotFound();
        }

        account.Balance = account.Balance + request.Balance;

        await _context.SaveChangesAsync();
        
        return account;
    }
}