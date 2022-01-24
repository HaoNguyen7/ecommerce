using System;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.EntityFrameworkCore;
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
                UserId = userId,
                GiayPhepKinhDoanh = request.GiayPhepKinhDoanh
            };

            var createResult = await _context.CuaHang.AddAsync(store);
            await _context.SaveChangesAsync();
            return createResult;
        }

        public async Task<PagedList<CuaHang>> GetInactiveStores(GetInactiveStoreRequest query)
        {
            var stores = from s in _context.CuaHang 
                         select s;
            stores = stores.Where(s => s.TinhTrang.Equals(false));
            return await PagedList<CuaHang>.CreateAsync(stores.AsNoTracking(), query.pageIndex, query.pageSize);
        }

        public async Task<PagedList<CuaHang>> GetStoreOfUser(ListStoreOfUserRequest query)
        {
            var stores = from s in _context.CuaHang
                         select s;
            if(query.id != null && query.id != Guid.Empty) {
                stores = stores.Where(s => s.UserId.Equals(query.id));
            }
            return await PagedList<CuaHang>.CreateAsync(stores.AsNoTracking(), query.pageIndex, query.pageSize);
        }
        public async Task<CuaHang> ActiveStore(ActiveStoreRequest query)
        {
            var store = _context.CuaHang.Find(query.id);
            store.TinhTrang = true;
            await _context.SaveChangesAsync();
            return store;
        }
    }
}