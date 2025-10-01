using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.Devices
{
    public class DeviceIndexViewModel
    {
        public List<Domain.Entities.Modem> ModemsWithSim { get; set; } = new();
        public List<Domain.Entities.SIMCard> SimCardsWithoutModem { get; set; } = new();

        public List<Domain.Entities.Modem> ModemsWithoutSim { get; set; } = new();
    }

}
