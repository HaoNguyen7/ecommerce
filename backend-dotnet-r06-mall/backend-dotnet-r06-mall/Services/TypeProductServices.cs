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
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend_dotnet_r06_mall.Services
{
    public class TypeProductServices
    {
        private readonly BanHangContext _context;


        public TypeProductServices(BanHangContext context)
        {
            _context = context;
        }

        public async Task<ICollection<LoaiSanPham>> GetLoaiSanPham()
        {
            return await _context.LoaiSanPham.ToListAsync();
        }

        public async Task<EntityEntry<LoaiSanPham>> CreateLoaiSanPham(TypeProductRequest request)
        {
            LoaiSanPham loai = new LoaiSanPham
            {
                LoaiId = new Guid(),
                Ten = request.LoaiSanPham,
            };

            var createResult = await _context.LoaiSanPham.AddAsync(loai);
            await _context.SaveChangesAsync();
            return createResult;
        }

    }
}
