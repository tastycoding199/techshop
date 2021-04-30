using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Data;
using TechShop.Models.Repositories;

namespace TechShop.Models.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TechShopDB(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TechShopDB>>()))
            {
                Category phoneC = new Category {CategoryName="Phone" };
                Category tabletC = new Category {CategoryName="Tablet" };


                Brand samsungB = new Brand { BrandName = "Samsung" };
                Brand appleB = new Brand { BrandName = "Apple" };
                Brand googleB = new Brand { BrandName = "Google" };


                List<CategoryBrand> categoryBrand = new List<CategoryBrand>
                {
                    new CategoryBrand {Category=phoneC,Brand=samsungB},
                    new CategoryBrand {Category=phoneC,Brand=appleB},
                    new CategoryBrand {Category=phoneC,Brand=googleB},

                    //-----------------------------------------------
                    new CategoryBrand {Category=tabletC,Brand=samsungB},
                    new CategoryBrand {Category=tabletC,Brand=appleB},
                };


                context.Categories.Add(phoneC);
                context.Categories.Add(tabletC);


                context.Brands.Add(samsungB);
                context.Brands.Add(appleB);
                context.Brands.Add(googleB);

                foreach (var item in categoryBrand)
                {
                    context.CategoryBrands.Add(item);
                }


                List<Product> products = new List<Product>
                {
                    new Product
                    {
                        ProductName="Samsung Galaxy S21 Ultra",
                        Price=30000000,
                        Screen="6.7' Quad HD+,Dynamic AMOLED 2x,120HZ",
                        Ram=16,
                        Storage=512,
                        Battery=5000,
                        CPU="Exynos 2100 octa-core",
                        Picture="s21u.png",
                        Category=phoneC,
                        Brand=samsungB
                    },
                    new Product
                    {
                        ProductName="Apple Iphone 12 Pro Max",
                        Price=42000000,
                        Screen="6.7'",
                        Ram=6,
                        Storage=512,
                        Battery=3687,
                        CPU="A14 Bionic",
                        Picture="ip12pm.png",
                        Category=phoneC,
                        Brand=appleB
                    },
                    new Product
                    {
                        ProductName="Google Pixel 5",
                        Price=40000000,
                        Screen="6.0'",
                        Ram=8,
                        Storage=128,
                        Battery=4080,
                        CPU="Snapdragon 765 5G",
                        Picture="pixel5.png",
                        Category=phoneC,
                        Brand=googleB
                    },
                    new Product
                    {
                        ProductName="Samsung Galaxy Tab S7+",
                        Price=25000000,
                        Screen="12.4'",
                        Ram=8,
                        Storage=512,
                        Battery=10090,
                        CPU="Snapdragon 865 5G+",
                        Picture="Tab7.png",
                        Category=tabletC,
                        Brand=samsungB
                    },
                    new Product
                    {
                        ProductName="Apple Ipad Pro 2",
                        Price=35000000,
                        Screen="12.9'",
                        Ram=6,
                        Storage=1024,
                        Battery=9720,
                        CPU="Apple A12Z Bionic",
                        Picture="ipadpro.png",
                        Category=tabletC,
                        Brand=appleB
                    },
                };

                foreach (var item in products)
                {
                    context.Products.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
