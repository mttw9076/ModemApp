using AutoMapper;
using MediatR;
using WebApp.Application.Devices;
using WebApp.Application.Exceptions;
using WebApp.Application.Modem;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.SIMCard.Queries.GetSIMCardById
{
    public class GetSIMCardByIdHandler : IRequestHandler<GetSIMCardByIdQuery, DeviceDto>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetSIMCardByIdHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> Handle(GetSIMCardByIdQuery request, CancellationToken cancellationToken)
        {
            var simCard = await _repository.GetSIMCardById(request.SIMId);

            if (simCard == null)
                throw new NotFoundException($"Karta SIM o ID '{request.SIMId}' nie została znaleziona.");

            var deviceDto = new DeviceDto
            {
                SimCard = _mapper.Map<SimCardDTO>(simCard),
                Modem = simCard.Modem != null ? _mapper.Map<ModemDTO>(simCard.Modem) : null
            };

            return deviceDto;
        }
    }
}
