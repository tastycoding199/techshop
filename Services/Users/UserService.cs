using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechShop.Models.Auth;
using TechShop.Models.Jwt;
using TechShop.Models.Respones;
using TechShop.Models.Repositories;
using System.Text;
using AutoMapper;
using TechShop.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TechShop.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly JwtSettings _jwtSettings;

        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, JwtSettings jwtSettings, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateRole(string username, string role)
        {
            IdentityResult IR = null;
            if (!await _roleManager.RoleExistsAsync(role))
            {
                IR = await _roleManager.CreateAsync(new IdentityRole(role));
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                IR = await _userManager.AddToRoleAsync(user, role);
            }

            return IR;
        }

        public async Task<RegisterRespone> Rigister(User user)
        {
            var existUser = await _userManager.FindByNameAsync(user.UserName);

            try
            {
                if (existUser == null)
                {
                    var myUser = new ApplicationUser { UserName = user.UserName };

                    var result = await _userManager.CreateAsync(myUser, user.Password);

                    if (result.Succeeded)
                    {
                        var crole = await CreateRole(user.UserName, user.Role);

                        if (crole.Succeeded)
                        {
                            return new RegisterRespone { status = true, data = "Register Sucessfully!", error = "" };
                        }

                    }
                    return new RegisterRespone { status = false, data = "", error = "Register have not done." };
                }
                return new RegisterRespone { status = false, data = "", error = "Username is already exist" };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new RegisterRespone { status = false, data = "", error = ex.Message };
            }
        }

        public async Task<LoginRespone> Login(User user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName,user.Password, false, false);

            if (result.Succeeded)
            {
                var myUser = await _userManager.FindByNameAsync(user.UserName);

                if (user != null)
                {
                    var role = await _userManager.GetRolesAsync(myUser);

                    string userRole = role.FirstOrDefault();

                    var token = GenergateToken(new User { UserName = myUser.UserName, Role = userRole }, myUser.Id);

                    if (token.Success)
                    {
                        GetUserDTO authUser = _mapper.Map<GetUserDTO>(myUser);

                        authUser.Role = userRole;

                        return new LoginRespone { Success=true,Token = token.Token,User=authUser,Error=""};
                    }
                    return new LoginRespone { Success = false, Token = "", Error = token.error,User=null };
                }
                return new LoginRespone { Success = false, Token = "", Error = "User have not found.",User=null };

            }
            return new LoginRespone { Success=false,Token = "" ,Error="Username or Password are not correct",User=null};
        }

        public CreateTokenRespone GenergateToken(User user, string id)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var secretKey = _jwtSettings.getSkey();
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,id),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddMinutes(5)).ToUnixTimeSeconds().ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var token = tokenHandler.WriteToken(tokenOptions);

                return new CreateTokenRespone
                {
                    Success = true,
                    Token = token,
                    error=""
                };
            }
            catch (Exception ex)
            {
                return new CreateTokenRespone { Success = false, Token = "" ,error=ex.Message};
            }

            
        }
    }
}
