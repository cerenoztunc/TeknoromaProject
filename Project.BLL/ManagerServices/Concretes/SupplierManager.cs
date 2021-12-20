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
    public class SupplierManager:BaseManager, ISupplierService
    {
        public SupplierManager(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        public async Task<SupplierDto> ListSupplier()
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
    }
}
