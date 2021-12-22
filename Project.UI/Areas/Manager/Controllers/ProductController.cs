using Mapster;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.COMMON.Results.Abstract;
using Project.COMMON.Results.ComplexTypes;
using Project.COMMON.Results.Concrete;
using Project.ENTITIES.DTOs;
using Project.UI.Areas.Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            IDataResult<ProductListDto> result = await _productService.ListProductAsync();
            if (result.ResultStatus == ResultStatus.Success)
                return View(result.Data);
            return NotFound();
        }
        public async Task<IActionResult> CreateProduct()
        {
            CategoryDto categoryDto = await _categoryService.ListAsync();
            SupplierDto supplierDto = await _supplierService.ListSupplierAsync();
            AddProductViewModel addProductViewModel = new AddProductViewModel
            {
                Categories = categoryDto.Categories,
                Suppliers = supplierDto.Suppliers
            };
            return View(addProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                AddProductDto addProductDto = addProductViewModel.Adapt<AddProductDto>();
                bool result = await _productService.AddProductAsync(addProductDto);
                if (result)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.result = "false";
                }
            }
            return View(addProductViewModel);
        }
    }
}
