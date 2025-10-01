using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class SIMCard
    {
        [Key]
        public int SIMId { get; set; }
        public string ?PhoneNumber { get; set; } = default!;
        public string ?USIM { get; set; } = default!;
        public string ?PIN { get; set; } = default!;
        public string ?PUK { get; set; } = default!;
        public string ?Op { get; set; } = default!;
        public string ?IP { get; set; } = default!;
        public  Modem? Modem { get; set; }
        public int? ModemId { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
