using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class CategoryDto
    {
        public Category Category { get; set; }
        public string Message { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
