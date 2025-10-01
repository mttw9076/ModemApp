using MediatR;
using WebApp.Application.Modem;

namespace WebApp.Application.Devices.Commands.CreateSimCard
{
    public class CreateSimCardCommand : SimCardDTO , IRequest
    {
    }
}
