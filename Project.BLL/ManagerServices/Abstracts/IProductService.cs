using Project.COMMON.Results.Abstract;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IProductService
    {
        Task<ProductDto> ListProductAsync();
        Task<bool> AddProductAsync(AddProductDto addProductDto);
        Task DeleteProductAsync(int id);
        Task<ProductDto> FindByIdProduct(int id);
        Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ProductDto> GetDeletedProductsAsync();
        Task<bool> MakeProductActive(int id);
        Task<ProductDto> SortingProductsByStock();
    }
}
