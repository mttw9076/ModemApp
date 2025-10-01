using MediatR;
using WebApp.Application.Modem;

namespace WebApp.Application.Devices.Commands.CreateModem
{
    public class CreateModemCommand :  ModemDTO , IRequest
    {
    }
}
