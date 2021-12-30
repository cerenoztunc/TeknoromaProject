using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; } //ürün hala satılıyor mu
        public string QuantityPerUnit { get; set; } //birim başına miktar
        public short UnitsOnOrder { get; set; } //sipariş üzerine birimler
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
