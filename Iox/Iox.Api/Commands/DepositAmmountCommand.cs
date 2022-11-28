using MediatR;
using Iox.Api.Models;

namespace Iox.Api.Commands;

public class DepositAmmountCommand : IRequest<Account>
{
    public Account Account { get; set; }
    public DepositAmmountCommand(Account account)
    {
        Account = account;
    }
}