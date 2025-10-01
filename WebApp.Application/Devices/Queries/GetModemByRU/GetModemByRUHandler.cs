using AutoMapper;
using MediatR;
using WebApp.Application.Exceptions;
using WebApp.Application.Devices;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Modem.Queries.GetModemByRU
{
    public class GetModemByRUHandler : IRequestHandler<GetModemByRUQuery, DeviceDto>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetModemByRUHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> Handle(GetModemByRUQuery request, CancellationToken cancellationToken)
        {
            var modem = await _repository.GetModemByRU(request.RU);

            if (modem == null)
                throw new NotFoundException($"Modem with RU '{request.RU}' not found.");

            var deviceDto = new DeviceDto
            {
                Modem = _mapper.Map<ModemDTO>(modem),
                SimCard = modem.SIMCard != null ? _mapper.Map<SimCardDTO>(modem.SIMCard) : null
            };

            return deviceDto;
        }
    }
}
