using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Models.Repositories;

namespace TechShop.DTOs
{
    public class AddBillDetailDTO
    {
        public Bill Bill { get; set; } = null;

        public int ProductId { get; set; }

        public int Quanlity { get; set; }

        public int Price { get; set; }
    }
}
