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


        public async Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AddAppUserDto userDto, string password)
        {
            AppUser user = userDto.Adapt<AppUser>();
            if (user.Picture == null)
            {
                user.Picture ="/picture/profile.jpg";
                
                IdentityResult addUserResult = await _userManager.CreateAsync(user, password);
                
                await AssignRoleAsync(userDto);
                if (addUserResult.Succeeded)
                {
                    return new DataResult<AddAppUserDto>(ResultStatus.Success, Messages.AppUser.AddAsync(user.FirstName), userDto);

                }
                return new DataResult<AddAppUserDto>(ResultStatus.Error, userDto);
            }
            else
            {
                IdentityResult addUserRes = await _userManager.CreateAsync(user, password);
                await AssignRoleAsync(userDto);
                if (addUserRes.Succeeded)
                {
                    return new DataResult<AddAppUserDto>(ResultStatus.Success, Messages.AppUser.AddAsync(user.FirstName), userDto);

                }
                return new DataResult<AddAppUserDto>(ResultStatus.Error, userDto);
            }
            
        }
        
        public async Task AssignRoleAsync(AddAppUserDto addUserDto)
        {
            AppUser appUser = addUserDto.Adapt<AppUser>();
            AppUser findUser = await _userManager.FindByNameAsync(appUser.UserName);
            foreach (var item in addUserDto.UserRoles)
            {
                if (item.Exist)
                    await _userManager.AddToRoleAsync(findUser, item.Name);
                else
                    await _userManager.RemoveFromRoleAsync(findUser, item.Name);
            }
        }
        public AppUserDto ListAppUserAsync()
        {
            List<AppUser> users = _userManager.Users.ToList();
            
            return new AppUserDto
            {
                AppUsers = users,
            };

        }



    }
}
