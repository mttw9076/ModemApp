using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class Shops
    {
        public int ID { get; set; } 
        public string shopNumber { get; set; } = default!;
        public string ShopCity { get; set; } = default!;
    }
}
