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
using Microsoft.AspNetCore.Hosting;
using Project.ENTITIES.Enums;
using MoreLinq;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager, IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHostingEnvironment _hostEnvironment;
        public AppUserManager(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IHostingEnvironment hostEnvironment) : base(unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AddAppUserDto userDto, string password, IFormFile userPicture)
        {
            AppUser user = userDto.Adapt<AppUser>();
            if (userPicture == null)
            {
                user.Picture = "/UserPicture/profile.jpg";

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
                await UploadImage.UploadImageAsync(userPicture, user);
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
            List<AppUser> users = _userManager.Users.Where(x => x.Status != DataStatus.Deleted).ToList();

            return new AppUserDto
            {
                AppUsers = users,
            };
        }

        public async Task DeleteUser(int id)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            user.DeletedDate = DateTime.Now;
            user.Status = ENTITIES.Enums.DataStatus.Deleted;
            await _userManager.UpdateAsync(user);
        }
        public async Task<AppUserDto> GetDeletedUsersAsync()
        {
            var deletedUsers = _userManager.Users.Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted).ToList();
            AppUserDto appUserDto = new AppUserDto();
            if (deletedUsers.Count > -1)
            {
                appUserDto.AppUsers = deletedUsers;
            }
            else
            {
                appUserDto.Message = "Herhangi bir eski çalışan bulunmamaktadır";
            }
            return appUserDto;

        }
        public async Task MakeUserActiveAysnc(int id)
        {
            AppUser appUser = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = ENTITIES.Enums.DataStatus.Updated;
            await _userManager.UpdateAsync(appUser);
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
        public async Task<bool> UpdateUser(UpdateAppUserDto updateAppUserDto, IFormFile userPicture)
        {
            AppUser appUser = await FindUser(updateAppUserDto.Id);
            if (_userManager.Users.Any(u => u.PhoneNumber == updateAppUserDto.PhoneNumber) && appUser.PhoneNumber != updateAppUserDto.PhoneNumber)
            {
                return false;
            }
            if (userPicture != null)
            {
                if (appUser.Picture == null)
                {
                    if (userPicture != null && userPicture.Length > 0)
                    {
                        await UploadImage.UploadImageAsync(userPicture, appUser);
                    }

                }
                else
                {
                    if (appUser.Picture != "/UserPicture/profile.jpg")
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", appUser.Picture);
                        var toBeDeleted = oldPath.Split("/")[2];
                        var fullPath = _hostEnvironment.WebRootPath + "/UserPicture/" + toBeDeleted;
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        await UploadImage.UploadImageAsync(userPicture, appUser);
                    }
                    await UploadImage.UploadImageAsync(userPicture, appUser);
                }

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
        public async Task<AppUserDto> GetSalesOfAppUserAsync(int userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId.ToString());
            List<OrderDetail> orderDetails = UnitOfWork.OrderDetails.GetActives();
            List<Order> orders = orderDetails.Select(x => x.Order).ToList();
            List<Order> ordersOfAppUser = orders.Where(x => x.AppUserId == userId).ToList();
            AppUserDto appUserDto = new AppUserDto
            {
                Orders = ordersOfAppUser
            };
            return appUserDto;
        }
        public async Task<List<UsersMonthlySalesDto>> GetMonthlySalesOfAppUserAsync(int userId)
        {            

            var a = (from au in UnitOfWork.AppUsers.GetAll()
                     join o in UnitOfWork.Orders.GetAll() on au.Id equals o.AppUserId
                     join od in UnitOfWork.OrderDetails.GetAll() on o.Id equals od.OrderId
                     where o.AppUserId == userId
                     select new UsersMonthlySalesDto()
                     {
                         CreatedDate = od.CreatedDate,
                         ProductId = od.ProductId,
                         OrderId = od.OrderId,
                         ProductName = od.Product.ProductName,
                         UnitPrice = od.UnitPrice,
                         TotalPrice = UnitOfWork.OrderDetails.Where(x=>x.ProductId == od.ProductId && x.Order.AppUserId == userId).Sum(x=>x.UnitPrice * x.Quantity),
                         TotalQuantity = UnitOfWork.OrderDetails.Where(x=>x.ProductId == od.ProductId && x.Order.AppUserId == userId).Sum(x=>x.Quantity)
                     }).DistinctBy(x=>x.ProductId).Where(x=>x.CreatedDate.AddDays(30) > DateTime.Now).ToList();
            return a;

        }

        public async Task<List<AppUserAndSalesDto>> GetAppUserAndSalesAsync()
        {
            var a = (from au in UnitOfWork.AppUsers.GetAll()
                     join o in UnitOfWork.Orders.GetAll() on au.Id equals o.AppUserId
                     join od in UnitOfWork.OrderDetails.GetAll() on o.Id equals od.OrderId
                     select new AppUserAndSalesDto()
                     {
                         AppUserId = au.Id,
                         FirstName = au.FirstName,
                         LastName = au.LastName,
                         ProductId = od.ProductId,
                         OrderId = od.OrderId,
                         TotalPrice = UnitOfWork.Orders.Where(x => x.AppUserId == au.Id).SelectMany(x=>x.OrderDetails).Sum(x => x.UnitPrice * x.Quantity),
                         TotalQuantity = UnitOfWork.Orders.Where(x => x.AppUserId == au.Id).SelectMany(x=>x.OrderDetails).Sum(x => x.Quantity)
                     }).DistinctBy(x => x.AppUserId).ToList();
            return a;
        }
        public async Task<List<TopTenSellingProductsDto>> TopTenSellingProductsAsync()
        {
            var a = (from p in UnitOfWork.Products.GetActives()
                     join s in UnitOfWork.Suppliers.GetActives() on p.SupplierId equals s.Id
                     join od in UnitOfWork.OrderDetails.GetActives() on p.Id equals od.ProductId
                     join o in UnitOfWork.Orders.GetActives() on od.OrderId equals o.Id
                     join c in UnitOfWork.Customers.GetActives() on o.CustomerId equals c.Id
                     select new TopTenSellingProductsDto()
                     {
                         OrderId = o.Id,
                         ProductId = p.Id,
                         ProductName = p.ProductName,
                         UnitsInOrder = p.UnitsOnOrder,
                         CompanyName = s.CompanyName,
                         BirthDatesAverage = UnitOfWork.Products.GetActives().SelectMany(x => x.OrderDetails).Where(x => x.ProductId == p.Id).Select(x => x.Order).Select(x => x.Customer).Average(x=>x.BirthDate.Year),
                         Genders = UnitOfWork.Products.GetActives().SelectMany(x => x.OrderDetails).Where(x => x.ProductId == p.Id).Select(x => x.Order).Select(x => x.Customer).Select(x => x.Gender).ToList()
                     }).DistinctBy(x=>x.ProductName).OrderByDescending(x => x.UnitsInOrder).Take(10).ToList();
            return a;
        }
        public async Task<TopTenSellingsWithThemTheBestSellingsDto> TopTenSellingsAndWithThemTheBestSellings(int orderId, int productId)
        {
            List<OrderDetail> orderDetails = UnitOfWork.OrderDetails.GetActives().Where(x => x.OrderId == orderId).ToList();
            List<Product> products = orderDetails.Select(x => x.Product).OrderByDescending(x => x.UnitsOnOrder).Where(x=>x.Id!=productId).Take(10).DistinctBy(x => x.ProductName).ToList();
            TopTenSellingsWithThemTheBestSellingsDto topTenSellingsWithThemTheBestSellingsDto = new TopTenSellingsWithThemTheBestSellingsDto
            {
                Products = products
            };
            
            return topTenSellingsWithThemTheBestSellingsDto;

            //var a = (from p in UnitOfWork.Products.GetAll()
            //         join od in UnitOfWork.OrderDetails.GetActives() on p.Id equals od.ProductId
            //         join o in UnitOfWork.Orders.GetActives() on od.OrderId equals o.Id
            //         where p.Id == productId
            //         select new TopTenSellingsWithThemTheBestSellingsDto()
            //         {
            //             ProductName = p.ProductName,
            //             UnitPrice = p.UnitPrice,
            //         }).DistinctBy(x => x.ProductId).ToList();
            //return a;

        }


    }
}
