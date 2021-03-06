using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class AppUserDto
    {
        public List<AppUser> AppUsers { get; set; }
        public string Message { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
