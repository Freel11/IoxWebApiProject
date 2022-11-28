using MediatR;
using Iox.Api.Models;

namespace Iox.Api.Commands;

public class CreateNewUserCommand : IRequest<User>
{

    public User User { get; set; }

    public CreateNewUserCommand(User user)
    {
        User = user;
    }
}