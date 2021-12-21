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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            CategoryDto categoryListDto = await _categoryService.ListAsync();
            return View(categoryListDto);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                AddCategoryDto addCategoryDto = addCategoryViewModel.Adapt<AddCategoryDto>();
                bool result = await _categoryService.CreateCategoryAsync(addCategoryDto);
                if (result)
                    return RedirectToAction("Index");
                else
                    ViewBag.result = "false";
                    return View(addCategoryViewModel);
            }
            return View(addCategoryViewModel);
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            CategoryDto category = await _categoryService.FindByIdAsync(id);
            UpdateCategoryViewModel updateCategoryViewModel = new UpdateCategoryViewModel
            {
                CategoryName = category.Category.CategoryName,
                Description = category.Category.Description
            };
            return View(updateCategoryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateCategoryDto updateCategoryDto = updateCategoryViewModel.Adapt<UpdateCategoryDto>();
                bool result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                if (result)
                    return RedirectToAction("Index");
                else
                    ViewBag.result = "false";
            }
            return View(updateCategoryViewModel);
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetDeletedCategories()
        {
            CategoryDto deletedCategories = await _categoryService.GetDeletedCategorisAsync();
            return View(deletedCategories);
        }
        public async Task<IActionResult> MakeCategoryActive(int id)
        {
            await _categoryService.MakeCategoryActiveAysnc(id);
            return RedirectToAction("Index");
        }
    }
}
