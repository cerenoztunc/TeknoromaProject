using Project.COMMON.Results.Abstract;
using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IProductService
    {
        Task<IDataResult<ProductListDto>> GetAllAsync();
        Task<IDataResult<ProductListDto>> GetActivesAsync();
        Task<IDataResult<ProductListDto>> GetPassivesAsync();
        Task<IDataResult<ProductListDto>> GetModifiedsAsync();
    }
}
