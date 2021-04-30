using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechShop.Models.Auth;
using TechShop.Models.Errors;
using TechShop.Models.Respones;
using TechShop.Services.Users;

namespace TechShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<DataRespone<string>> register(User user)
        {
            if (user == null)
            {
                throw new MyBadRequestException("Please Provide username and password.");
            }
            RegisterRespone regis = await _userService.Rigister(user);

            if (!regis.status)
            {
                throw new MyBadRequestException(regis.error);
            }
            return new DataRespone<string>
            {
                Status = true,
                Data = regis.data,
                Errors = null
            };
        }

        [HttpPost]
        [Route("Login")]
        public async Task<DataRespone<AuthenticationUser>> login(User user)
        {
            if (user == null)
            {
                throw new MyBadRequestException("Please Provide username and password.");
            }
            LoginRespone log = await _userService.Login(user);

            if (!log.Success)
            {
                throw new MyUnauthorizedException(log.Error);
            }
            return new DataRespone<AuthenticationUser>
            {
                Status = true,
                Data= new AuthenticationUser { Token=log.Token,User=log.User},
                Errors=null
            };
        }
    }
}
