using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;

namespace TechShop.Models.Respones
{
    public class CreateTokenRespone
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string error { get; set; }
    }
}
