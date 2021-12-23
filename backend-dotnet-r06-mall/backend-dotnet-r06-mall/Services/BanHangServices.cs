using System;
using System.Collections.Generic;
using System.Linq;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Services
{
    public class BanHangServices
    {
        private readonly BanHangContext _context;

        public BanHangServices(BanHangContext context)
        {
            _context = context;
        }

        public IEnumerable<SanPham> GetAllSanPham()
        {
            return _context.SanPham!
            .Include(t => t.LoaiSanPham)
            .Include(t => t.CuaHang)
            .AsNoTracking()
            .ToList();
        }

        public IEnumerable<LoaiSanPham> GetAllLoaiSanPham()
        {
            return _context.LoaiSanPham!
            .AsNoTracking()
            .ToList();
        }

        public IEnumerable<DonHang> GetAllDonHang()
        {
            return _context.DonHang!
            .Include(t => t.TinhTrangDonHang)
            .Include(t => t.DonHangSanPham)
            .Include(t => t.KhachHang)
            .Include(t => t.NguoiGiaoHang)
            .AsNoTracking()
            .ToList();
        }

        public async void CreateKhachHang(KhachHang khachHang)
        {
            await _context.KhachHang.AddAsync(khachHang);
            await _context.SaveChangesAsync();
        }

    }
}