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

        public SanPham? GetById(int id)
        {
            return _context.SanPham!
            .Include(p => p.TenSanPham)
            .Include(p=> p.SanPhamId)
            .Include(p=>p.DonGia)
            .Include(p=>p.DonVi)
            .Include(p=>p.CuaHang)
            .AsNoTracking()
            .SingleOrDefault(p=>p.SanPhamId = id);//loi cho nay?
            
        }
    }
}