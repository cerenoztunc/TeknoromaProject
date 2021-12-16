using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface ICategoryService
    {
        Task<CategoryDto> ListAsync();
        Task<bool> CreateCategoryAsync(AddCategoryDto addCategoryDto);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto> FindByIdAsync(int id);
        Task DeleteCategoryAsync(int id);
        Task<CategoryDto> GetDeletedCategorisAsync();
        Task MakeCategoryActiveAysnc(int id);
    }
}
