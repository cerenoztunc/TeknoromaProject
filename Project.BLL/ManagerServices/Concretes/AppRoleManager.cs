using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.Results.Abstract;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppRoleManager:BaseManager,IAppRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AppRoleManager(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
       

        public async Task CreateAppRoleAsync(string roleName)
        {
            AppRole role = new AppRole()
            {
                Name = roleName
            };
            if(await _roleManager.RoleExistsAsync(roleName))
            {
                 await _roleManager.CreateAsync(role);
            }
        }
        public List<AppRole> Roles()
        {
            return _roleManager.Roles.ToListAsync().Result;
        }
        
    }
}
