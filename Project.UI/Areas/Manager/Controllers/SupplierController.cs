using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.DTOs;
using Project.UI.Areas.Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            SupplierDto suppliers = await _supplierService.ListSupplier();
            return View(suppliers);
        }
        public IActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(AddSupplierViewModel addSupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                AddSupplierDto addSupplierDto = addSupplierViewModel.Adapt<AddSupplierDto>();

                bool result = await _supplierService.CreateSupplierAsync(addSupplierDto);
                if(result)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.result = "false";
                    return View(addSupplierViewModel);
                }
            }
                return View(addSupplierViewModel);
        }
    }
}
