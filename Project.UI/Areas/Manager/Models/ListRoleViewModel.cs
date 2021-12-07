using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class ListRoleViewModel
    {
        public List<AppRole> AppRoles { get; set; }
        public string Message { get; set; }
    }
}
