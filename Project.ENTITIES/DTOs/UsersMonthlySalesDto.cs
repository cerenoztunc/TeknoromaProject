using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class UsersMonthlySalesDto
    {
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
