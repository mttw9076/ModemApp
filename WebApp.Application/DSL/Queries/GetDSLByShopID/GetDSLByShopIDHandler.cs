using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.DSL.Queries.GetDSLByShopID
{
    public class GetDSLByShopIDHandler : IRequestHandler<GetDSLByShopIDQuery, DSLDTO>
    {
        private readonly IDSLRepository repository;
        private readonly IMapper mapper;

        public GetDSLByShopIDHandler(IDSLRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<DSLDTO> Handle(GetDSLByShopIDQuery request, CancellationToken cancellationToken)
        {
            var dsl = await repository.GetByShopID(request.ShopID);
            return mapper.Map<DSLDTO>(dsl);
        }
    }
}
