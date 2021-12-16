using Mapster;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<CategoryDto> ListAsync()
        {
            List<Category> categories = UnitOfWork.Categories.GetActives();
            CategoryDto categoryListDto = new CategoryDto();
            if (categories.Count > 0)
            {
                categoryListDto.Categories = categories;
                return categoryListDto;
            }
            else
            {
                categoryListDto.Message = "Hiçbir aktif kategori bulunmamaktadır";
                return categoryListDto;
            }
        }
        public async Task<bool> CreateCategoryAsync(AddCategoryDto addCategoryDto)
        {
            List<Category> categories = UnitOfWork.Categories.GetActives();
            Category category = addCategoryDto.Adapt<Category>();

            if (categories.Where(x => x.CategoryName == category.CategoryName).Any())
            {
                return false;
            }
            else
            {
                UnitOfWork.Categories.Add(category);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }
        public async Task<CategoryDto> FindByIdAsync(int id)
        {
            Category category = UnitOfWork.Categories.Where(x => x.Id == id).FirstOrDefault();
            CategoryDto categoryDto = new CategoryDto
            {
                Category = category
            };
            return categoryDto;
        }
        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            List<Category> categories = UnitOfWork.Categories.GetActives();
            Category category = updateCategoryDto.Adapt<Category>();
            if (categories.Where(x => x.CategoryName == category.CategoryName).Any())
            {
                return false;
            }
            else
            {
                UnitOfWork.Categories.Update(category);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }
        public async Task DeleteCategoryAsync(int id)
        {
            Category category = UnitOfWork.Categories.Where(x => x.Id == id).FirstOrDefault();
            category.DeletedDate = DateTime.Now;
            category.Status = ENTITIES.Enums.DataStatus.Deleted;
            await UnitOfWork.SaveAysnc();
        }
        public async Task<CategoryDto> GetDeletedCategorisAsync()
        {
            List<Category> deletedCategories = UnitOfWork.Categories.GetPassives();
            CategoryDto categoryDto = new CategoryDto();
            if (deletedCategories.Count > 0)
            {
                categoryDto.Categories = deletedCategories;
            }
            else
            {
                categoryDto.Message = "Hiçbir pasif kategori bulunmamaktadır";
            }
           
            return categoryDto;
        }
        public async Task MakeCategoryActiveAysnc(int id)
        {
            Category category = UnitOfWork.Categories.Where(x => x.Id == id).FirstOrDefault();
            category.ModifiedDate = DateTime.Now;
            category.Status = ENTITIES.Enums.DataStatus.Updated;
            await UnitOfWork.SaveAysnc();
        }
    }
}
