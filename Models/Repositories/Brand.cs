using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class Brand
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        [StringLength(10)]
        public string BrandName { get; set; }

        public List<CategoryBrand> CategoryBrands { get; set; }

        public List<Product> Products { get; set; }
    }
}
