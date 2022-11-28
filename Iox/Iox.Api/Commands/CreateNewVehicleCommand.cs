using MediatR;
using Iox.Api.Models;

namespace Iox.Api.Commands;

public class CreateNewVehicleCommand : IRequest<Vehicle>
{

    public Vehicle Vehicle { get; set; }

    public CreateNewVehicleCommand(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
}