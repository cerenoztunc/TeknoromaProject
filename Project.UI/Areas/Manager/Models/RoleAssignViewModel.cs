using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class RoleAssignViewModel
    {
        [Display(Name = "Pozisyon Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Var Mı?")]
        public bool Exist { get; set; }
    }
}
