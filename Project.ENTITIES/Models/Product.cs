using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int MyProperty { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public bool Discontinued { get; set; } //ürün hala satılıyor mu
        public string QuantityPerUnit { get; set; } //birim başına miktar
        public short UnitsOnOrder { get; set; } //sipariş üzerine birimler

        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
