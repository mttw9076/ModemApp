using AutoMapper;
using MediatR;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.DSL.Queries.GetAllDSL
{
    public class GetAllDSLQueryHandler : IRequestHandler<GetAllDSLQuery, IEnumerable<DSLDTO>>
    {
        private readonly IDSLRepository repository;
        private readonly IMapper mapper;

        public GetAllDSLQueryHandler( IDSLRepository repository , IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<DSLDTO>> Handle(GetAllDSLQuery request, CancellationToken cancellationToken)
        {
            var dsls = await repository.GetAll();
            return mapper.Map<IEnumerable<DSLDTO>>(dsls);
        }
    }
}
