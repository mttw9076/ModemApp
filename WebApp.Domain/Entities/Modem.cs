using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{

    public class Modem
    {
        public int  ModemId { get; set; }
        public string ? Model { get; set; } = default!;
        public string ? SerialNumber { get; set; } = default!;
        public string? RU { get; set; } = default!;
        public SIMCard? SIMCard { get; set; }
        public string? PrevShopID { get; set; } = default!;
        public string? ShopID { get; set; } = default!;
        public string? Place { get; set; } = default!;
        public string? Description { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? ModifiedById { get; set; }
        public IdentityUser? ModifiedByUser { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
