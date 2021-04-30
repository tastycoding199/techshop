using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Errors;
using TechShop.Models.Respones;
using TechShop.Services.Cart;

namespace TechShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public async Task<DataRespone<string>> AddToCart(AddToCartDTO addToCartDTO)
        {
            if (addToCartDTO == null)
            {
                throw new MyBadRequestException("Your cart is null.");
            }

            DataResp result = await _cartService.addToCart(addToCartDTO.Bill, addToCartDTO.BillDetail);

            if (!result.Success)
            {
                throw new MyBadRequestException(result.Error);
            }

            return new DataRespone<string> { Status = true, Data = "Congrat!Adding to cart is sucess", Errors = null };
        }
    }
}
