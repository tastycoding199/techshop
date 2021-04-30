using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class CategoryBrand
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }


        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
