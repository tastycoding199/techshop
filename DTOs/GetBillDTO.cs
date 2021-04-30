using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTOs
{
    public class GetBillDTO
    {
        public int BillId { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public DateTime Date { get; set; }

        public int TotalPrice { get; set; }

        public string UserId { get; set; }
    }
}
