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


        public async Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AppUser user, string password)
        {
            if(user.Picture == null)
            {
                user.Picture ="/picture/profile.jpg";
                IdentityResult addUserRes = await _userManager.CreateAsync(user, password);
                AddAppUserDto addAppUserDto = user.Adapt<AddAppUserDto>();
                if (addUserRes.Succeeded)
                {
                    return new DataResult<AddAppUserDto>(ResultStatus.Success, Messages.AppUser.AddAsync(user.FirstName), addAppUserDto);

                }
                return new DataResult<AddAppUserDto>(ResultStatus.Error, addAppUserDto);
            }
            else
            {
                IdentityResult addUserRes = await _userManager.CreateAsync(user, password);
                AddAppUserDto addAppUserDto = user.Adapt<AddAppUserDto>();
                if (addUserRes.Succeeded)
                {
                    return new DataResult<AddAppUserDto>(ResultStatus.Success, Messages.AppUser.AddAsync(user.FirstName), addAppUserDto);

                }
                return new DataResult<AddAppUserDto>(ResultStatus.Error, addAppUserDto);
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
