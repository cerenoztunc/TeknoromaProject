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
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Order> OrdersOfUsers { get; set; }
        public List<OrderDetail> OrderDetailsOfUsers { get; set; }
    }
}
