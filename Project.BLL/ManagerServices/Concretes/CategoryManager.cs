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
    public class CategoryManager:BaseManager, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        public async Task<CategoryListDto> ListAsync()
        {
            List<Category> categories = UnitOfWork.Categories.GetActives();
            CategoryListDto categoryListDto = new CategoryListDto();
            if (categories.Count > 0)
            {
                categoryListDto.Categories = categories;
                return categoryListDto;
            }
            else
            {
                categoryListDto.Message = "Herhangi bir kategori bulunmamaktadır";
                return categoryListDto;
            }
        }
    }
}
