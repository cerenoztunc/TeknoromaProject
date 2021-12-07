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

namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly IAppUserService _userManager;
        private readonly IAppRoleService _roleManager;
     
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
        public IActionResult AddUser()
        {
            List<AssignRoleDto> roles =_roleManager.ReturnRoles();
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            addUserViewModel.UserRoles = roles;
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AddAppUserDto addAppUserDto = addUserViewModel.Adapt<AddAppUserDto>();
                var result = await _userManager.CreateAppUserAsync(addAppUserDto, addAppUserDto.Password);
                
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(addUserViewModel);
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
            bool result  = await _roleManager.CreateAppRoleAsync(role.Name);
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
    }
}
