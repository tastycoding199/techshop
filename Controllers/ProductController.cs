using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Errors;
using TechShop.Models.Respones;
using TechShop.Services.Products;

namespace TechShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<DataRespone<List<GetProductDTO>>> getProducts(int CategoryId, int BrandId)
        {
            if(CategoryId==0 || BrandId == 0)
            {
                throw new MyBadRequestException("Category ID and Brand ID cannot be null ");
            }
            List<GetProductDTO> products = await _productService.products(CategoryId, BrandId);

            if (products == null || products.Count<=0)
            {
                throw new MyNotFoundException("Not Found any Products with "+CategoryId+" and "+BrandId);
            }


            return new DataRespone<List<GetProductDTO>>
            {
                Status = true,
                Data = products,
                Errors = null
            };
        }
        
        [HttpGet("{ProductId}")]
        public async Task<DataRespone<GetProductDTO>> GetProduct(int ProductId)
        {
            if (ProductId == 0)
            {
                throw new MyBadRequestException("Product ID cannot be null ");
            }

            GetProductDTO product = await _productService.getProduct(ProductId);

            if (product == null)
            {
                throw new MyNotFoundException("Product "+ProductId+" have not found.");
            }

            return new DataRespone<GetProductDTO>
            {
                Status = true,
                Data = product,
                Errors = null
            };
        }

        [HttpPost]
        public async Task<DataRespone<List<GetProductDTO>>> search(SearchDTO search)
        {
            List<GetProductDTO> products = await _productService.SearchProduct(search.ProductName);

            return new DataRespone<List<GetProductDTO>>
            {
                Status = true,
                Data = products,
                Errors = null
            };
        }
    }
}
