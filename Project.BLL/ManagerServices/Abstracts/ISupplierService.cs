using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface ISupplierService
    {
        Task<SupplierDto> ListSupplierAsync();
        Task<bool> CreateSupplierAsync(AddSupplierDto addSupplierDto);
        Task<bool> UpdateSupplierAsync(UpdateSupplierDto updateSupplierDto);
        Task<SupplierDto> FindByIdAsync(int supplierId);
        Task DeleteSupplierAsync(int id);
        Task<SupplierDto> GetOldSuppliersAsync();
        Task MakeSupplierActiveAsync(int id);
        Task<SupplierDto> GetMonthlyOrderedProductsFromSuppliersAsync(int supplierId);
        Task<SupplierDto> GetAllOrderedProductsFromSuppliersAsync(int supplierId);
    }
}
