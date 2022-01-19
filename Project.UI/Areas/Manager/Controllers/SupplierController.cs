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
            SupplierDto suppliers = await _supplierService.ListSupplierAsync();
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
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            SupplierDto supplierDto = await _supplierService.FindByIdAsync(id);
            UpdateSupplierViewModel updateSupplierViewModel = supplierDto.Supplier.Adapt<UpdateSupplierViewModel>();
            return View(updateSupplierViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierViewModel updateSupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateSupplierDto updateSupplierDto = updateSupplierViewModel.Adapt<UpdateSupplierDto>();
                bool result = await _supplierService.UpdateSupplierAsync(updateSupplierDto);
                if(result)
                    return RedirectToAction("Index");
                else
                    ViewBag.result = "false";
            }
            return View(updateSupplierViewModel);
        }
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OldSuppliers()
        {
            SupplierDto oldSuppliers = await _supplierService.GetOldSuppliersAsync();
            return View(oldSuppliers);
        }
        public async Task<IActionResult> MakeSupplierActive(int id)
        {
            await _supplierService.MakeSupplierActiveAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetProducts(int id)
        {
            SupplierDto supplierDto = await _supplierService.FindByIdAsync(id);
            ViewBag.companyName = supplierDto.Supplier.CompanyName;
            ProductDto productDto = await _supplierService.GetProducts(id);
            return View(productDto);
        }
        public async Task<IActionResult> SupplierAct()
        {
            SupplierDto supplierDto = await _supplierService.ListSupplierAsync();
            return View(supplierDto);
        }
        public async Task<IActionResult> MonthlyOrderedProductsFromSupplier(int supplierId)
        {
            SupplierDto orderedProducts = await _supplierService.OrderedProductsFromSuppliersAsync(supplierId);
            return PartialView("SupplierProductsContentPartial", orderedProducts);
        }
        public async Task<IActionResult> AllOrderedProductsFromSupplier(int supplierId)
        {
            SupplierDto allOrderedProducts = await _supplierService.AllOrderedProductsFromSuppliersAsync(supplierId);
            return PartialView("SupplierProductsContentPartial", allOrderedProducts);
        }

    }
}
