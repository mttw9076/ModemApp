using AutoMapper;
using MediatR;
using WebApp.Application.ApplicationUser;
using WebApp.Application.Devices.Commands.CreateModem;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Device.Commands.CreateDevice
{
    public class CreateModemCommandHandler : IRequestHandler<CreateModemCommand>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateModemCommandHandler(IDeviceRepository deviceRepository, IMapper mapper, IUserContext userContext)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public IUserContext UserContext { get; }

        public async Task<Unit> Handle(CreateModemCommand request, CancellationToken cancellationToken)
        {

            var modem = _mapper.Map<Domain.Entities.Modem>(request);
            modem.CreatedAt = DateTime.UtcNow;
            modem.CreatedById = _userContext.GetCurrentUser().UserId;
            await _deviceRepository.CreateModem(modem);

            return Unit.Value;

        }
    }
}
