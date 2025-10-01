using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email)
        {
            UserId = id;
            Email = email;
        }
       public string? UserId { get; set; } 
       public string? Email { get; set; } 


    }
}
