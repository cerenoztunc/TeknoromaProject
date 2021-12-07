using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.Results.Abstract;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
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
       

        public async Task<bool> CreateAppRoleAsync(string roleName)
        {
            AppRole role = new AppRole()
            {
                Name = roleName
            };
            if(!(await _roleManager.RoleExistsAsync(roleName)))
            {
                 await _roleManager.CreateAsync(role);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<AppRole> Roles()
        {
            return _roleManager.Roles.ToListAsync().Result;
        }
        public List<AssignRoleDto> ReturnRoles()
        {
            IQueryable<AppRole> roles = _roleManager.Roles;
            List<AssignRoleDto> assignRoleDtos = new List<AssignRoleDto>();
            AddAppUserDto addAppUserDto = new AddAppUserDto();
            foreach (var item in roles)
            {
                AssignRoleDto assignRoleDto = new AssignRoleDto();
                assignRoleDto.Id = item.Id;
                assignRoleDto.Name = item.Name;
                assignRoleDtos.Add(assignRoleDto);

                addAppUserDto.UserRoles = assignRoleDtos;

            }
            return addAppUserDto.UserRoles;
        }
    }
}
