using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITIES.Models;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.ViewComponents
{
    public class UserMenuViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public UserMenuViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) return Content("Kullanıcı Bulunamadı!");
            return View(new AppUserViewModel
            {
                AppUser = user
            });
        }
    }
}
