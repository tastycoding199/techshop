using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Data;
using TechShop.DTOs;
using TechShop.Models.Repositories;

namespace TechShop.Services.Nav
{
    public class NavService : INavService
    {
        private readonly TechShopDB _db;
        public NavService(TechShopDB db)
        {
            _db = db;
        }

        public async Task<List<GetNavDTO>> getNav()
        {
            List<Category> categories = await _db.Categories.AsNoTracking()
                .Include(p => p.CategoryBrands)
                .ThenInclude(b => b.Brand).ToListAsync();

            List<GetNavDTO> navs = new List<GetNavDTO>(); 

            foreach (var item in categories)
            {
                List<GetBrandDTO> brands = new List<GetBrandDTO>();
                foreach (var item2 in item.CategoryBrands)
                {
                    var data = item2.Brand;
                    brands.Add(new GetBrandDTO { BrandId = data.BrandId, BrandName = data.BrandName });
                }
                navs.Add(new GetNavDTO { CategoryId = item.CategoryId, CategoryName = item.CategoryName, Brands = brands });
            }
            return navs;
        }
    }
}
