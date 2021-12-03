using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class ProductListDto : BaseDto
    {
        public List<Product> Products { get; set; }
        public int? CategoryId { get; set; }
    }
}
