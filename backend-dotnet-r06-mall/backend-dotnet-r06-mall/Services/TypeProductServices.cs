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
        private readonly SaleContext _context;


        public TypeProductServices(SaleContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<EntityEntry<Category>> CreateLoaiSanPham(TypeProductRequest request)
        {
            Category loai = new Category
            {
                CategoryName = request.LoaiSanPham,
            };

            var createResult = await _context.Categories.AddAsync(loai);
            await _context.SaveChangesAsync();
            return createResult;
        }

    }
}
