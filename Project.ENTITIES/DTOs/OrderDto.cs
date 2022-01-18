using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class OrderDto
    {
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
