using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using Project.UI.Areas.Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.COMMON.Results.ComplexTypes;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DAL.Abstracts.Repositories;
using Project.COMMON.Results.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly IAppUserService _userManager;
        private readonly IAppRoleService _roleManager;
        private readonly IOrderDetailService _orderDetailService;
     
        public HomeController(IAppUserService userManager, IAppRoleService roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.ListAppUserAsync();
            if (users.AppUsers.Count > 0)
                return View(users);
            else
            {
                ViewBag.error = "Kullanıcı bulunamadı";
            return View();
            }
                
        }
        public async Task<IActionResult> OldUsers()
        {
            AppUserDto deletedUsers = await _userManager.GetDeletedUsersAsync();
            return View(deletedUsers);
        }
        public async Task<IActionResult> MakeUserActive(int id)
        {
            await _userManager.MakeUserActiveAysnc(id);
            return RedirectToAction("Index");
        }
        public IActionResult AddUser()
        {
            List<AssignRoleDto> roles =_roleManager.ReturnRoles();
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            addUserViewModel.UserRoles = roles;
            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel,IFormFile userPicture)
        {
            if (ModelState.IsValid)
            {
                AddAppUserDto addAppUserDto = addUserViewModel.Adapt<AddAppUserDto>();
               
                var result = await _userManager.CreateAppUserAsync(addAppUserDto, addAppUserDto.Password,userPicture);
                
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(addUserViewModel);
        }
        public async Task<IActionResult> UpdateUser(int id)
        {
            AppUser user= await _userManager.FindUser(id);
            List<AssignRoleDto> roles = await _userManager.FindUserRole(id);
            UpdateUserViewModel updateUserViewModel = user.Adapt<UpdateUserViewModel>();
            updateUserViewModel.UserRoles = roles;
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            return View(updateUserViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel,IFormFile userPicture)
        {
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            var errors = ModelState.Select(x => x.Value.Errors);
            if (ModelState.IsValid)
            {
                UpdateAppUserDto updateAppUserDto = updateUserViewModel.Adapt<UpdateAppUserDto>();
                var result = await _userManager.UpdateUser(updateAppUserDto,userPicture);
                ViewBag.result = "true";
                if (result)
                    return RedirectToAction("Index");
                else
                    ViewBag.result = "false";
            }
            return View(updateUserViewModel);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userManager.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public IActionResult Roles()
        {
            List<AppRole> roles = _roleManager.Roles();
            ListRoleViewModel listRoleViewModel = new ListRoleViewModel();
            if (roles.Count < 0)
            {
                listRoleViewModel.Message = "Hiçbir rol bulunamamaktadır.";
            }
            else
            {
                listRoleViewModel.AppRoles = roles;
            }
            return View(listRoleViewModel);
        }
        public IActionResult CreateRole()
        {
            CreateRoleViewModel createRoleViewModel = new CreateRoleViewModel();
            return View(createRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                bool result = await _roleManager.CreateAppRoleAsync(role.Name);
                if (result)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    role.Message = "Bu rol daha önce eklenmiştir.";
                    return View(role);
                }
            }
            else
                return View(role);
            
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleManager.DeleteRole(id);
            return RedirectToAction("Roles");
        }
        public async Task<IActionResult> UpdateRole(int id)
        {
            AppRole appRole = await _roleManager.FindRole(id);
            UpdateRoleViewModel updateRoleViewModel = appRole.Adapt<UpdateRoleViewModel>();
            return View(updateRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateAppRoleDto updateAppRoleDto = updateRoleViewModel.Adapt<UpdateAppRoleDto>();
                var result = await _roleManager.UpdateRole(updateAppRoleDto);
                ViewBag.result = "true";
                if (result)
                    return RedirectToAction("Roles");
                else
                {
                    ViewBag.result = "false";
                    return View();
                }
            }
            else
                return View(updateRoleViewModel);
        }
        public async Task<IActionResult> SalesTrackingReport()
        {
            List<AppUserAndSalesDto> appUserAndSalesDto = await _userManager.GetAppUserAndSalesAsync();
            return View(appUserAndSalesDto);
        }
        public async Task<IActionResult> GetMonthlySalesOfAppUser(int appUserId)
        {
            List<UsersMonthlySalesDto> appUserAndSalesDto = await _userManager.GetMonthlySalesOfAppUserAsync(appUserId);
            return PartialView("MonthlySalesTrackingContentPartial", appUserAndSalesDto);
        }

    }
}
