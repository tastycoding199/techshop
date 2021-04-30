using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTOs
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public int Price { get; set; }
        
        public string Screen { get; set; }

        public int Ram { get; set; }

        public int Storage { get; set; }

        public string CPU { get; set; }

        public int Battery { get; set; }


        public string Picture { get; set; }

        public int Sale { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
