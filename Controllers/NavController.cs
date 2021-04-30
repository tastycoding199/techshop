using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Errors;
using TechShop.Models.Repositories;
using TechShop.Models.Respones;
using TechShop.Services.Nav;

namespace TechShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavController : ControllerBase
    {
        private readonly INavService _navService;

        public NavController(INavService navService)
        {
            _navService = navService;
        }

        [HttpGet]
        public async Task<DataRespone<List<GetNavDTO>>> Get()
        {
            List<GetNavDTO> getNavs = await _navService.getNav();

            if (getNavs == null || getNavs.Count <= 0)
            {
                throw new MyNotFoundException("Not found");
            }
            return new DataRespone<List<GetNavDTO>>
            {
                Status = true,
                Data = getNavs,
                Errors = null
            };

        }
    }
}
