using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IAppRoleService
    {
        Task<bool> CreateAppRoleAsync(string roleName);
        List<AppRole> Roles();
        List<AssignRoleDto> ReturnRoles();
        Task DeleteRole(int id);
        Task<AppRole> FindRole(int id);
        Task<bool> UpdateRole(UpdateAppRoleDto updateAppRoleDto);
    }
}
