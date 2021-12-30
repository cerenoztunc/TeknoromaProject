using Mapster;
using Microsoft.AspNetCore.Http;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.Utilities;
using Project.COMMON.Results.Abstract;
using Project.COMMON.Results.ComplexTypes;
using Project.COMMON.Results.Concrete;
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
    public class ProductManager : BaseManager, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ProductDto> ListProductAsync()
        {
            List<Product> products = UnitOfWork.Products.GetActives();
            ProductDto productDto = new ProductDto();
            if (products.Count > 0)
            {
                productDto.Products = products;
            }
            else
            {
                productDto.Message = "Herhangi bir ürün bulunmamaktadır!";
            }
            return productDto;
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

        public async Task<ProductDto> FindByIdProduct(int id)
        {
            Product findedProduct = UnitOfWork.Products.Find(id);
            ProductDto productDto = new ProductDto
            {
                Product = findedProduct
            };
            return productDto;
        }
        public async Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            List<Product> products = UnitOfWork.Products.GetActives();
            ProductDto product = await FindByIdProduct(updateProductDto.Id);
            Product updatedProduct = updateProductDto.Adapt<Product>();
            if (products.Where(x=>x.ProductName == updatedProduct.ProductName).Any() && updatedProduct.ProductName != product.Product.ProductName)
            {
                return false;
            }
            else
            {
                UnitOfWork.Products.Update(updatedProduct);
                await UnitOfWork.SaveAysnc();
                return true;
            }
        }
        
        public async Task DeleteProductAsync(int id)
        {
            UnitOfWork.Products.Delete(UnitOfWork.Products.Find(id));
            await UnitOfWork.SaveAysnc();
        }
        public async Task<ProductDto> GetDeletedProductsAsync()
        {
            List<Product> deletedProducts = UnitOfWork.Products.GetPassives();
            ProductDto productDto = new ProductDto();
            if (deletedProducts.Count > 0)
            {
                productDto.Products = deletedProducts;
            }
            else
            {
                productDto.Message = "Bütün ürünler aktif!";
            }

            return productDto;
        }
        public async Task<bool> MakeProductActive(int id)
        {
            Product product = UnitOfWork.Products.Find(id);
            if(product != null)
            {
                product.ModifiedDate = DateTime.Now;
                product.Status = DataStatus.Updated;
                await UnitOfWork.SaveAysnc();
                return true;
            }
            return false;
        }
    }
}
