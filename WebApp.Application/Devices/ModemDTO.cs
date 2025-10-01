using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.Modem
{
    public class ModemDTO
    {
        public int? ModemId { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? RU { get; set; }
        public string? PrevShopID { get; set; }
        public string? ShopID { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }

        // SIMCard może być null — modem bez przypisanej karty
        public SimCardDTO? SIMCard { get; set; }

    }
}
