using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; }
    }
}
