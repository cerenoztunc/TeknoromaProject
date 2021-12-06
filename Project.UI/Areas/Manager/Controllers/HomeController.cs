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
        private readonly UserManager<AppUser> userManager1;
        private readonly RoleManager<AppRole> roleManager1;
        public HomeController(IAppUserService userManager, IAppRoleService roleManager, UserManager<AppUser> userManager1, RoleManager<AppRole> roleManager1)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.userManager1 = userManager1;
            this.roleManager1 = roleManager1;
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
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            IQueryable<AppRole> roles = roleManager1.Roles;
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.RoleId = item.Id;
                roleAssignViewModel.RoleName = item.Name;
                roleAssignViewModels.Add(roleAssignViewModel);

                addUserViewModel.AppRoles = roleAssignViewModels;
                
            }
            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                AppUser appUser = addUserViewModel.Adapt<AppUser>();
                var result = await _userManager.CreateAppUserAsync(appUser, addUserViewModel.Password);
                AppUser user = await userManager1.FindByNameAsync(appUser.UserName);
                foreach (var item in addUserViewModel.AppRoles)
                {
                    if (item.Exist)
                        await userManager1.AddToRoleAsync(user, item.RoleName);
                    else
                        await userManager1.RemoveFromRoleAsync(user, item.RoleName);
                }
                
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(addUserViewModel);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task CreateRole(CreateRoleViewModel role)
        {
            await _roleManager.CreateAppRoleAsync(role.Name);

        }
    }
}
