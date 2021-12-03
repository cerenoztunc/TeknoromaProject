using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.Utilities;
using Project.COMMON.Results.Abstract;
using Project.COMMON.Results.ComplexTypes;
using Project.COMMON.Results.Concrete;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProductManager : BaseManager, IProductManager
    {
        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IDataResult<ProductListDto>> GetActivesAsync()
        {
            var products = UnitOfWork.Products.GetActives();
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductListDto>> GetModifiedsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductListDto>> GetPassivesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
