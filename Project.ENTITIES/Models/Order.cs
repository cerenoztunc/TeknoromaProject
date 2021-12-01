using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string ShipAddress { get; set; }
        public decimal Freight { get; set; } //taşıma ücreti
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int CustomerId { get; set; }
        public int AppUserId { get; set; }

        //Relational Properties
        public virtual Customer Customer { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
