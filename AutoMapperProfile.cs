using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.DTOs;
using TechShop.Models.Repositories;

namespace TechShop
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDTO>();

            //---------------------------------
            CreateMap<AddBillDTO, Bill>();

            CreateMap<Bill, GetBillDTO>();
            //---------------------------------
            CreateMap<AddBillDetailDTO, BillDetail>();

            //--------------------------------------
            CreateMap<ApplicationUser, GetUserDTO>();

            //-----------------------------------------
        }
    }
}
