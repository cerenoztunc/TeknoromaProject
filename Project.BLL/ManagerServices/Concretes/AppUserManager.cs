using Mapster;
using Microsoft.AspNetCore.Http;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager, IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserManager(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager) : base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AddAppUserDto userDto, string password, IFormFile userPicture)
        {
            AppUser user = userDto.Adapt<AppUser>();
            if (userPicture == null)
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
                await UploadImage(userPicture, user);
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

        public async Task DeleteUser(int id)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
        }
        public async Task<AppUser> FindUser(int id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());
            return appUser;
        }
        public async Task<List<AssignRoleDto>> FindUserRole(int id)
        {
            AppUser appUser = await FindUser(id);
            IQueryable<AppRole> roles = _roleManager.Roles;
            List<string> userRoles = await _userManager.GetRolesAsync(appUser) as List<string>;
            List<AssignRoleDto> assignRoleDtos = new List<AssignRoleDto>();
            UpdateAppUserDto updateAppUserDto = new UpdateAppUserDto();
            foreach (var item in roles)
            {
                AssignRoleDto assignRoleDto = new AssignRoleDto();
                assignRoleDto.Id = item.Id;
                assignRoleDto.Name = item.Name;
                if (userRoles.Contains(item.Name))
                    assignRoleDto.Exist = true;
                else
                    assignRoleDto.Exist = false;
                assignRoleDtos.Add(assignRoleDto);

                updateAppUserDto.UserRoles = assignRoleDtos;

            }
            return updateAppUserDto.UserRoles;
        }
        public async Task<bool> UpdateUser(UpdateAppUserDto updateAppUserDto)
        {
            AppUser appUser = await FindUser(updateAppUserDto.Id);
            if (_userManager.Users.Any(u => u.PhoneNumber == updateAppUserDto.PhoneNumber) && appUser.PhoneNumber != updateAppUserDto.PhoneNumber)
            {
                return false;
            }
            if (appUser.Picture == null)
            {
                appUser.Picture = "/picture/profile.jpg";
            }
            if (appUser != null)
            {
                appUser.BirthDate = updateAppUserDto.BirthDate;
                appUser.Gender = updateAppUserDto.Gender;
                appUser.UserName = updateAppUserDto.UserName;
                appUser.FirstName = updateAppUserDto.FirstName;
                appUser.LastName = updateAppUserDto.LastName;
                appUser.PhoneNumber = updateAppUserDto.PhoneNumber;
                appUser.Email = updateAppUserDto.Email;
                appUser.ModifiedDate = DateTime.Now;
                appUser.Status = ENTITIES.Enums.DataStatus.Updated;
               
                IdentityResult result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(appUser);
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(appUser, true);
                    AddAppUserDto addAppUserDto = updateAppUserDto.Adapt<AddAppUserDto>();
                    await AssignRoleAsync(addAppUserDto);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static async Task UploadImage(IFormFile userPicture, AppUser user)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", fileName);
            using var stream = new FileStream(path, FileMode.Create);
            await userPicture.CopyToAsync(stream);
            user.Picture = "/UserPicture/" + fileName;
        }

    }
}
