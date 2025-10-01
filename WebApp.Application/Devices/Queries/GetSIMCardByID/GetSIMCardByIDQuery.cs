using MediatR;
using WebApp.Application.Devices;

namespace WebApp.Application.SIMCard.Queries.GetSIMCardById
{
    public class GetSIMCardByIdQuery : IRequest<DeviceDto>
    {
        public int SIMId { get; set; }

        public GetSIMCardByIdQuery(int simId)
        {
            SIMId = simId;
        }
    }
}
