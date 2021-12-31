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
    
        public async Task<bool> TaoDonHang(CartRequest gh, Guid userId)
        {
            DonHang dh = new DonHang
            {
                DonHangId = new Guid(),
                ThoiGian = DateTime.UtcNow,
                TinhTrangThanhToan = false,
                KhachHang = await _context.KhachHang.FirstOrDefaultAsync(o => o.KhachHangId == userId)
            };

            dh.DonHangSanPham = new List<DonHangSanPham>();

            foreach (var item in gh.listsp)
            {
                DonHangSanPham dhsp = new DonHangSanPham
                {
                    DonHang = dh,
                    SanPham = await _context.SanPham.FirstOrDefaultAsync(o => o.SanPhamId == item.idsp)
                };
                dh.DonHangSanPham.Add(dhsp);
            }

            var createResult = await _context.DonHang.AddAsync(dh);
            return createResult is null ? false :  true;
        }
        public async Task<IList<DonHangSanPham>> loadDonHang(Guid donHangId)
        {
            //tra ve gio hang theo ma don hang trong bang DonHangSanPham
            var s =  await _context.DonHang.Include(q=> q.DonHangSanPham).FirstOrDefaultAsync(q=> q.DonHangId == donHangId);
            return s.DonHangSanPham;
        }
    }
}