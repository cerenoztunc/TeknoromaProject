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
            ProductDto productDto = await _productService.ListProductAsync();
            return View(productDto);
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
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ProductDto productDto = await _productService.FindByIdProduct(id); 
            CategoryDto categoryDto = await _categoryService.ListAsync();
            SupplierDto supplierDto = await _supplierService.ListSupplierAsync();
            UpdateProductViewModel updateProductViewModel = new UpdateProductViewModel
            {
                Id = productDto.Product.Id,
                ProductName = productDto.Product.ProductName,
                QuantityPerUnit = productDto.Product.QuantityPerUnit,
                Categories = categoryDto.Categories,
                Suppliers = supplierDto.Suppliers,
                UnitsInStock = productDto.Product.UnitsInStock,
                UnitsOnOrder = productDto.Product.UnitsOnOrder,
                Discontinued = productDto.Product.Discontinued,
                UnitPrice = productDto.Product.UnitPrice,
                CategoryId = productDto.Product.CategoryId,
                SupplierId = productDto.Product.SupplierId,
                
            };
            return View(updateProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateProductDto updateProductDto = updateProductViewModel.Adapt<UpdateProductDto>();
                bool result = await _productService.UpdateProductAsync(updateProductDto);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.result = "false";
                    return View(updateProductViewModel);
                }
            }
            else
            {
                ModelState.AddModelError("", "İşlem Başarısız!");
            }
            return View(updateProductViewModel);
            
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetDeletedProducts()
        {
            ProductDto deletedProducts = await _productService.GetDeletedProductsAsync();
            return View(deletedProducts);
        }
        public async Task<IActionResult> MakeProductActive(int id)
        {
            bool result = await _productService.MakeProductActive(id);
            if (result)
                return RedirectToAction("Index");
            else
            {
                ProductDto productDto = new ProductDto
                {
                    Message = "Böyle bir ürün bulunmamaktadır"
                };
                return RedirectToAction("GetDeletedProducts", productDto);
            }
                
        }
        public async Task<IActionResult> StockTrackingReport()
        {
            ProductDto productDto = await _productService.SortingProductsByStock();
            return View(productDto);
        }
    }
}
