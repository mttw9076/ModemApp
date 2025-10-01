using MediatR;
using WebApp.Application.Modem;

namespace WebApp.Application.Devices.Queries.GetAllModem
{
    public class GetAllDevicesQuery : IRequest<IEnumerable<DeviceDto>>
    {

    }
}
