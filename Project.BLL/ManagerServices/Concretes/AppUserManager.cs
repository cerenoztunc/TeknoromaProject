using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.Utilities;
using Project.COMMON.Results.Abstract;
using Project.COMMON.Results.ComplexTypes;
using Project.COMMON.Results.Concrete;
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
    public class AppUserManager : BaseManager, IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserManager(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AppUser user)
        {
            var res = await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, "admin");
            AddAppUserDto addAppUserDto = user.Adapt<AddAppUserDto>();

            if (res.Succeeded)
            {
                var result = new DataResult<AddAppUserDto>(ResultStatus.Success, Messages.AppUser.AddAsync(user.FirstName), addAppUserDto);
                return result;
            }
            return new DataResult<AddAppUserDto>(ResultStatus.Error, Messages.AppUser.AddAsyncError(), addAppUserDto);
            
        }
        public async Task CreateAppRoleAsync(string roleName)
        {
            AppRole role = new AppRole()
            {
                Name = roleName
            };

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist)
            {
                await _roleManager.CreateAsync(role);
            }
            
        }


        public AppUserDto ListAppUserAsync()
        {
            List<AppUser> users = UnitOfWork.AppUsers.GetAll();
            return new AppUserDto
            {
                AppUsers = users
            };
        }



    }
}
