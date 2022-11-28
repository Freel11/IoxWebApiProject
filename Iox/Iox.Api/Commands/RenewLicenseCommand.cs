using MediatR;
using Iox.Api.Models;

namespace Iox.Api.Commands;

public class RenewLicenseCommand : IRequest<Vehicle>
{
    public Vehicle Vehicle { get; set; }
    public RenewLicenseCommand(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
}