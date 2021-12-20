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
        Task<SupplierDto> ListSupplier();
        Task<bool> CreateSupplierAsync(AddSupplierDto addSupplierDto);
    }
}
