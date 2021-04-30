using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTOs
{
    public class GetNavDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<GetBrandDTO> Brands { get; set; }

    }
}
