using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class Bill
    {
        [Required]
        public int BillId { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public List<BillDetail> BillDetails { get; set; }
    }
}
