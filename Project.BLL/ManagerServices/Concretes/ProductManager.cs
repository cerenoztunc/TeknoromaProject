using Mapster;
using Microsoft.AspNetCore.Http;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.Utilities;
using Project.COMMON.Results.Abstract;
using Project.COMMON.Results.ComplexTypes;
using Project.COMMON.Results.Concrete;
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
    public class ProductManager : BaseManager, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IDataResult<ProductListDto>> ListProductAsync()
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
        public async Task<bool> AddProductAsync(AddProductDto addProductDto)
        {
            List<Product> products = UnitOfWork.Products.GetActives();
            Product product = addProductDto.Adapt<Product>();
            if (products.Where(x => x.ProductName == product.ProductName).Any())
                return false;
            else
            {
                UnitOfWork.Products.Add(product);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }

    }
}
