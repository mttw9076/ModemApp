using MediatR;
using WebApp.Application.Modem;

namespace WebApp.Application.Device.Commands.EditDevice
{
    public class EditDeviceCommand : IRequest
    {
        public ModemDTO? Modem { get; set; }
        public SimCardDTO? SimCard { get; set; }

    }
}
