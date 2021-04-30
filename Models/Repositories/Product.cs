using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is not null")]
        [StringLength(25)]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }

        [StringLength(70)]
        public string Screen { get; set; }
        [Range(1,64)]
        public int Ram { get; set; }
        [Range(1,512)]
        public int Storage { get; set; }
        [StringLength(70)]
        public string CPU { get; set; }

        public int Battery { get; set; }

        [StringLength(100)]
        public string Picture { get; set; }

        [Range(1,100)]
        public int Sale { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }


        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public List<BillDetail> BillDetails { get; set; }
    }
}
