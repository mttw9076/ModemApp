using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Application.Devices;

namespace WebApp.Application.Modem.Queries.GetModemByRU
{
    public class GetModemByRUQuery : IRequest<DeviceDto>
    {
        public string RU { get; set; }
        public GetModemByRUQuery(string ru)
        {
            RU = ru;
        }
    }
}
