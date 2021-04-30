using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class BillDetail
    {
        [Required]
        public int BillId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quanlity { get; set; }
        [Required]
        public int Price { get; set; }

        public Bill Bill { get; set; }
        public Product Product { get; set; }
    }
}
