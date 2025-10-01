using AutoMapper;
using MediatR;
using WebApp.Application.Devices.Queries.GetAllModem;
using WebApp.Application.Modem;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Devices.Queries.GetAllDevices
{
    public class GetAllDevicesQueryHandler : IRequestHandler<GetAllDevicesQuery, IEnumerable<DeviceDto>>
    {
        private readonly IDeviceRepository repository;
        private readonly IMapper mapper;

        public GetAllDevicesQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDto>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
        {
            var modems = await repository.GetAllModemsWithSIMCards(); // np. Include(SIMCard)
            var devices = modems.Select(m => new DeviceDto
            {
                Modem = mapper.Map<ModemDTO>(m),
                SimCard = m.SIMCard != null ? mapper.Map<SimCardDTO>(m.SIMCard) : null
            });

            return devices;
        }
    }
}
