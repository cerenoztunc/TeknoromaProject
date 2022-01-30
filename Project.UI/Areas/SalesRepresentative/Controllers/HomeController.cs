using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.SalesRepresentative.Controllers
{
    [Area("SalesRepresentative")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
