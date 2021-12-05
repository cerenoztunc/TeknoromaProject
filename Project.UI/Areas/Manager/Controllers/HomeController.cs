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

namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly IAppUserManager _userManager;

        public HomeController(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
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
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task CreateRole(CreateRoleViewModel role)
        {
            await _userManager.CreateAppRoleAsync(role.RoleName);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                AppUser appUser = addUserViewModel.Adapt<AppUser>();
                var result = await _userManager.CreateAppUserAsync(appUser);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(addUserViewModel);
        }
    }
}
