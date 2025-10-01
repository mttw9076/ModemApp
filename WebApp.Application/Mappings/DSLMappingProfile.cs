using AutoMapper;
using WebApp.Application.DSL;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Application.DSL.Commands.EditDSL;

namespace WebApp.Application.Mappings
{
    public class DSLMappingProfile : Profile
    {
        public DSLMappingProfile()
        {
            CreateMap<DSLDTO, Domain.Entities.DSL>();
            CreateMap<Domain.Entities.DSL, DSLDTO>();
            CreateMap<DSLDTO, CreateDSLCommand>();
            CreateMap<CreateDSLCommand, DSLDTO>();
            CreateMap<DSLDTO, EditDSLCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<EditDSLCommand, Domain.Entities.DSL>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
