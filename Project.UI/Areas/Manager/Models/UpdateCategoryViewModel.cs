using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MaxLength(15, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string CategoryName { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string Description { get; set; }
    }
}
