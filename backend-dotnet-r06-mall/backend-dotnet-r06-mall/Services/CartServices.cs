using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Services
{
    public class CartServices
    {
        private readonly BanHangContext _context;


        public CartServices(BanHangContext context)
        {
            _context = context;
        }
        
        public async Task<DonHangSanPham> addProductToCart(DonHangSanPham dhsp)
        {
            IEnumerable<DonHangSanPham> products = await _context.DonHangSanPham.AsQueryable.Select();
            return 0;
        }

        public async Task<IList<DonHangSanPham>> loadDonHang(Guid donHangId)
        {
            //tra ve gio hang theo ma don hang trong bang DonHangSanPham
            var ds = await _context.DonHang.Include(q=> q.DonHangSanPham).FirstOrDefaultAsync(q=> q.DonHangId == donHangId);
        }
    }
}