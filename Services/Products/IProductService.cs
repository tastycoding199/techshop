using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Repositories;

namespace TechShop.Services.Products
{
    public interface IProductService
    {
        Task<List<GetProductDTO>> products(int CategoryId,int BrandId);
        Task<GetProductDTO> getProduct(int ProductId);
        Task<List<GetProductDTO>> SearchProduct(string ProductName);
    }
}
