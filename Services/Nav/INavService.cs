using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Repositories;

namespace TechShop.Services.Nav
{
    public interface INavService
    {
        Task<List<GetNavDTO>> getNav();
    }
}
