using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;

namespace TechShop.Models.Auth
{
    public class AuthenticationUser
    {
        public string Token { get; set; }
        public GetUserDTO User { get; set; }
    }
}
