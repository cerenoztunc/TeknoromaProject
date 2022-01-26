using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class TopTenSellingProductsDto
    {
        public int UnitsInOrder { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public List<Customer> Customers { get; set; }
        public double BirthDatesAverage { get; set; }
        public List<Gender> Genders { get; set; }
    }
}
