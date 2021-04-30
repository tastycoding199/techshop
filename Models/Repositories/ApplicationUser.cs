using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Repositories
{
    public class ApplicationUser :IdentityUser
    {
        public List<Bill> Bills { get; set; }
    }
}
