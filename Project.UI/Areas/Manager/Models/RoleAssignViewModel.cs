using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class RoleAssignViewModel
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public bool Exist { get; set; }
    }
}
