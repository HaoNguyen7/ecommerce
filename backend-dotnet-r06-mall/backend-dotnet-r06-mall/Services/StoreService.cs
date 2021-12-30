using System;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend_dotnet_r06_mall.Services
{
    public class StoreService
    {
        private readonly BanHangContext _context;
        public StoreService(BanHangContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<CuaHang>> CreateStore(Guid userId, RegisterStoreRequest request)
        {
            CuaHang store = new CuaHang
            {
                CuaHangId = new Guid(),
                TenCuaHang = request.Name,
                MoTa = request.Description,
                SoDienThoai = request.PhoneNumber,
                STK = request.CardId,
                DiaChi = request.Address,
                MaSoThue = request.TaxId,
                TinhTrang = false,
                UserId = userId
            };

            var createResult = await _context.CuaHang.AddAsync(store);
            await _context.SaveChangesAsync();
            return createResult;
        }
    }
}