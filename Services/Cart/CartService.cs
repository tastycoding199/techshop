using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Data;
using TechShop.DTOs;
using TechShop.Models.Repositories;
using TechShop.Models.Respones;

namespace TechShop.Services.Cart
{
    public class CartService : ICartService
    {

        private readonly TechShopDB _db;
        private readonly IMapper _mapper;

        public CartService(TechShopDB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DataResp> addToCart(AddBillDTO addBillDTO, List<AddBillDetailDTO> addBillDetailDTOs)
        {
            try
            {

                Bill bill = _mapper.Map<Bill>(addBillDTO);
                

                addBillDetailDTOs.ForEach(p => p.Bill = bill);

                List<BillDetail> billDetails = addBillDetailDTOs.Select(p => _mapper.Map<BillDetail>(p)).ToList();

                foreach (var billDetail in billDetails)
                {
                    _db.BillDetails.Add(billDetail);
                }

                _db.Bills.Add(bill);

                await _db.SaveChangesAsync();

                return new DataResp { Success = true, Error = "" };
            }
            catch (DbUpdateException ex)
            {

                return new DataResp { Success = false, Error = ex.Message };
            }
        }
    }
}
