using AutoMapper;
using MediatR;
using WebApp.Application.ApplicationUser;
using WebApp.Application.Devices.Commands.CreateSimCard;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Device.Commands.CreateDevice
{
    public class CreateSIMCardCommandHandler : IRequestHandler<CreateSimCardCommand>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext userContext;

        public CreateSIMCardCommandHandler(IDeviceRepository deviceRepository, IMapper mapper, IUserContext userContext)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<Unit> Handle(CreateSimCardCommand request, CancellationToken cancellationToken)
        {
            var simCard = _mapper.Map<Domain.Entities.SIMCard>(request);
            simCard.CreatedAt = DateTime.UtcNow;
            simCard.CreatedById = userContext.GetCurrentUser().UserId;
            await _deviceRepository.CreateSIMCard(simCard);

            return Unit.Value;
        }
    }
}
