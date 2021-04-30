using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTOs
{
    public class AddToCartDTO
    {
        public AddBillDTO Bill { get; set; }
        public List<AddBillDetailDTO> BillDetail { get; set; }
    }
}
