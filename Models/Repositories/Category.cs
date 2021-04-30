using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category Name is not null.")]
        [StringLength(10)]
        public string CategoryName { get; set; }


        public List<CategoryBrand> CategoryBrands { get; set; }

        public List<Product> Products { get; set; }
    }
}
