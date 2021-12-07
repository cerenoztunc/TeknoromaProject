using Microsoft.AspNetCore.Identity;
using Project.COMMON.Results.Abstract;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IAppUserService
    {
        Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AddAppUserDto userDto, string password);
        public AppUserDto ListAppUserAsync();
        Task AssignRoleAsync(AddAppUserDto addUserDto);
    }
}
