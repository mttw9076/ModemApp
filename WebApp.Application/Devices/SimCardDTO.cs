using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.Modem
{
    public class SimCardDTO
    {
        public int? SIMId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? USIM { get; set; }
        public string? PIN { get; set; }
        public string? PUK { get; set; }
        public string? Op { get; set; }
        public string? IP { get; set; }

        // ModemId może być null — karta bez przypisanego modemu
        public int? ModemId { get; set; }

        // ModemDto może być null — karta bez przypisanego modemu
        public ModemDTO? Modem { get; set; }
    }
}
