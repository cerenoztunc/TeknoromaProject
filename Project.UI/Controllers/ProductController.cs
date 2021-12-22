using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;

        public ProductController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productManager.ListProductAsync();
            return View(result.Data);
        }
        
    }
}
