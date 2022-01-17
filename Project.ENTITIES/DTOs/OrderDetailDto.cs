using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class OrderDetailDto
    {
        public OrderDetail OrderDetail { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ProductDto Products { get; set; }
        public string Message { get; set; }
        
    }
}
