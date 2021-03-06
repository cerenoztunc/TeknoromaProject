using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class UpdateRoleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Pozisyon Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string Name { get; set; }
    }
}
