using Microsoft.AspNetCore.Http;
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
        Task<IDataResult<AddAppUserDto>> CreateAppUserAsync(AddAppUserDto userDto, string password, IFormFile userPicture);
        public AppUserDto ListAppUserAsync();
        Task AssignRoleAsync(AddAppUserDto addUserDto);
        Task DeleteUser(int id);
        Task<AppUser> FindUser(int id);
        Task<bool> UpdateUser(UpdateAppUserDto updateAppUserDto, IFormFile userPicture);
        Task<List<AssignRoleDto>> FindUserRole(int id);
        Task<AppUserDto> GetDeletedUsersAsync();
        Task MakeUserActiveAysnc(int id);
        Task<AppUserDto> GetSalesOfAppUserAsync(int userId);
        Task<List<AppUserAndSalesDto>> GetAppUserAndSalesAsync();
        Task<List<UsersMonthlySalesDto>> GetMonthlySalesOfAppUserAsync(int userId);
        Task<List<TopTenSellingProductsDto>> TopTenSellingProductsAsync();
        Task<TopTenSellingsWithThemTheBestSellingsDto> TopTenSellingsAndWithThemTheBestSellings(int orderId, int productId);
    }
}
