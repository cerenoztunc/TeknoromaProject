using Mapster;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class SupplierManager:BaseManager, ISupplierService
    {
        public SupplierManager(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        public async Task<SupplierDto> ListSupplierAsync()
        {
            List<Supplier> suppliers = UnitOfWork.Suppliers.GetActives();
            SupplierDto supplierDto = new SupplierDto();
            if(suppliers.Count > 0)
                supplierDto.Suppliers = suppliers;
            else
                supplierDto.Message = "Herhangi bir tedarikçi bulunmamaktadır";
            return supplierDto;
        }
        
        public async Task<bool> CreateSupplierAsync(AddSupplierDto addSupplierDto)
        {
            List<Supplier> suppliers = UnitOfWork.Suppliers.GetActives();
            Supplier supplier = addSupplierDto.Adapt<Supplier>();
            if (suppliers.Where(x => x.CompanyName == supplier.CompanyName).Any())
            {
                return false;
            }
            else
            {
                UnitOfWork.Suppliers.Add(supplier);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }
        public async Task<bool> UpdateSupplierAsync(UpdateSupplierDto updateSupplierDto)
        {
            List<Supplier> suppliers = UnitOfWork.Suppliers.GetActives();
            SupplierDto oldSupplier = await FindByIdAsync(updateSupplierDto.Id);
            Supplier supplier = updateSupplierDto.Adapt<Supplier>();
            if (suppliers.Where(x => x.CompanyName == supplier.CompanyName).Any() && oldSupplier.Supplier.CompanyName != supplier.CompanyName)
                return false;
            else
            {
                UnitOfWork.Suppliers.Update(supplier);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }
        public async Task<SupplierDto> FindByIdAsync(int id)
        {
            Supplier supplier = UnitOfWork.Suppliers.Find(id);
            SupplierDto supplierDto = new SupplierDto
            {
                Supplier = supplier
            };
            return supplierDto;
        }
        public async Task DeleteSupplierAsync(int id)
        {
            UnitOfWork.Suppliers.Delete(UnitOfWork.Suppliers.Find(id));
            await UnitOfWork.SaveAysnc();
        }
        public async Task<SupplierDto> GetOldSuppliersAsync()
        {
            List<Supplier> suppliers = UnitOfWork.Suppliers.GetPassives();
            SupplierDto supplierDto = new SupplierDto();
            if (suppliers.Count > 0)
                supplierDto.Suppliers = suppliers;
            else
                supplierDto.Message = "Herhangi bir pasif tedarikçi bulunmamaktadır";

            return supplierDto;
        }
        public async Task MakeSupplierActiveAsync(int id)
        {
            Supplier passiveSupplier = UnitOfWork.Suppliers.Find(id);
            passiveSupplier.Status = DataStatus.Updated;
            passiveSupplier.ModifiedDate = DateTime.Now;
            await UnitOfWork.SaveAysnc();
        }
        public async Task<ProductDto> GetProducts(int id)
        {
            Supplier supplier = UnitOfWork.Suppliers.Find(id);
            List<Product> products = UnitOfWork.Products.Where(x => x.SupplierId == supplier.Id);
            ProductDto productDto = new ProductDto
            {
                Products = products
            };
            return productDto;
        }

        public async Task<SupplierDto> OrderedProductsFromSuppliersAsync(int supplierId)
        {
            Supplier supplier = UnitOfWork.Suppliers.Find(supplierId);
            List<Product> products = supplier.Products;
            var monthlyOrderedProduct = products.Where(x=>x.CreatedDate.AddDays(30).Date > DateTime.Now).ToList();
            SupplierDto supplierDto = new SupplierDto();
            if (monthlyOrderedProduct.Count > 0)
            {
                supplierDto.Products = monthlyOrderedProduct;
            }
            else
            {
                supplierDto.Message = "Aylık hiçbir sipariş bulunmamaktadır.";
            }
            return supplierDto;
        }
    }
}
