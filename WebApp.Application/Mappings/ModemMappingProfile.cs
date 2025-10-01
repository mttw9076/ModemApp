using AutoMapper;
using WebApp.Application.Device.Commands.EditDevice;
using WebApp.Application.Devices;
using WebApp.Application.Modem;

namespace WebApp.Application.Mappings
{
    public class ModemMappingProfile : Profile
    {
        public ModemMappingProfile()
        {
            // Modem → ModemDto
            CreateMap<Domain.Entities.Modem, ModemDTO>()
                .ForMember(dest => dest.SIMCard, opt => opt.MapFrom(src => src.SIMCard))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .PreserveReferences();

            // ModemDto → Modem
            CreateMap<ModemDTO, Domain.Entities.Modem>()
                .ForMember(dest => dest.SIMCard, opt => opt.MapFrom(src => src.SIMCard))
                .ForMember(dest => dest.ModemId, opt => opt.Ignore())
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place));// ⛔ unikamy ręcznego ustawiania ID


            // SIMCard → SimCardDto
            CreateMap<Domain.Entities.SIMCard, SimCardDTO>()
                .ForMember(dest => dest.ModemId, opt => opt.MapFrom(src => src.ModemId));

            // SimCardDto → SIMCard
            CreateMap<SimCardDTO, Domain.Entities.SIMCard>()
                .ForMember(dest => dest.Modem, opt => opt.Ignore())
                .ForMember(dest => dest.SIMId, opt => opt.Ignore()); // ⛔ jeśli SIMId jest generowany automatycznie
            CreateMap<DeviceDto, ModemDTO>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Modem.Model))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.Modem.SerialNumber));
            CreateMap<DeviceDto, EditDeviceCommand>()
                .ForMember(dest => dest.Modem, opt => opt.MapFrom(src => src.Modem))
                .ForMember(dest => dest.SimCard, opt => opt.MapFrom(src => src.SimCard));

            CreateMap<EditDeviceCommand, DeviceDto>()
                .ForMember(dest => dest.Modem, opt => opt.MapFrom(src => src.Modem))
                .ForMember(dest => dest.SimCard, opt => opt.MapFrom(src => src.SimCard));

        }
    }
}
