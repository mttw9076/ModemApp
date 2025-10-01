using MediatR;

namespace WebApp.Application.DSL.Queries.GetAllDSL
{
    public class GetAllDSLQuery : IRequest<IEnumerable<DSLDTO>>
    {
    }
}
