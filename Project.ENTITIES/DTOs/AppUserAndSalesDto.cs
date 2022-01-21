using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class AppUserAndSalesDto
    {
        public List<AppUser> AppUsers { get; set; } = new List<AppUser>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
