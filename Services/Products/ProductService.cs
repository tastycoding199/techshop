using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Data;
using TechShop.DTOs;
using TechShop.Models.Repositories;

namespace TechShop.Services.Products
{
    public class ProductService :IProductService
    {

        private readonly TechShopDB _db;
        private readonly IMapper _mapper;
        public ProductService(TechShopDB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        

        public async Task<List<GetProductDTO>> products(int CategoryId, int BrandId)
        {
            List<GetProductDTO> products = await _db.Products.Where(p => p.CategoryId == CategoryId && p.BrandId == BrandId)
                                            .OrderBy(p => p.ProductId).AsNoTracking()
                                            .Select(p => _mapper.Map<GetProductDTO>(p))
                                            .ToListAsync();
            return products;
        }

        public async Task<GetProductDTO> getProduct(int ProductId)
        {
            Product product = await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == ProductId);

            GetProductDTO productDTO = _mapper.Map<GetProductDTO>(product);

            return productDTO;
        }

        public async Task<List<GetProductDTO>> SearchProduct(string ProductName)
        {
            List<GetProductDTO> products = await _db.Products.Where(p => p.ProductName.ToLower()
                                          .Contains(ProductName.ToLower()))
                                          .Select(p => _mapper.Map<GetProductDTO>(p))
                                          .ToListAsync();

            return products;
        }
    }
}
