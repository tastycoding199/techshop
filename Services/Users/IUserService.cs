using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Models.Auth;
using TechShop.Models.Jwt;
using TechShop.Models.Respones;

namespace TechShop.Services.Users
{
    public interface IUserService
    {
        Task<RegisterRespone> Rigister(User user);
        Task<LoginRespone> Login(User user);
        Task<IdentityResult> CreateRole(string username, string role);
        CreateTokenRespone GenergateToken(User user, string id);
    }
}
