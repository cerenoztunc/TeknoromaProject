using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class SupplierDto
    {
        public Supplier Supplier { get; set; }
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; }
    }
}
