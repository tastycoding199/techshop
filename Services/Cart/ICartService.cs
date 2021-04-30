using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Respones;

namespace TechShop.Services.Cart
{
    public interface ICartService
    {
        Task<DataResp> addToCart(AddBillDTO addBillDTO,List<AddBillDetailDTO> addBillDetailDTOs);
    }
}
