using System;
using System.Collections.Generic;
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
        private readonly SaleContext _context;
        public StoreService(SaleContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<Store>> CreateStore(Guid userId, RegisterStoreRequest request)
        {
            Store store = new Store
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
                GiayPhepKinhDoanh = request.GiayPhepKinhDoanh,
                HoaHong = 0.2
            };

            var createResult = await _context.CuaHang.AddAsync(store);
            await _context.SaveChangesAsync();
            return createResult;
        }

        public async Task<List<Store>> GetInactiveStores(GetInactiveStoreRequest query)
        {
            var stores = from s in _context.CuaHang 
                         select s;
            stores = stores.Where(s => s.TinhTrang.Equals(false));
            
            var res = await stores.AsNoTracking().ToListAsync();
            return res;
        }

        public async Task<Store> GetInfoStore(GetStoreByIdRequest query)
        {
            var store = _context.CuaHang.Find(query.id);
            return store;
        }

        public async Task<PagedList<Store>> GetStoreOfUser(ListStoreOfUserRequest query)
        {
            var stores = from s in _context.CuaHang
                         select s;
            if(query.id != null && query.id != Guid.Empty) {
                stores = stores.Where(s => s.UserId.Equals(query.id));
            }
            return await PagedList<Store>.CreateAsync(stores.AsNoTracking(), query.pageIndex, query.pageSize);
        }
        public async Task<Store> ActiveStore(ActiveStoreRequest query)
        {
            var store = _context.CuaHang.Find(query.id);
            store.TinhTrang = true;
            await _context.SaveChangesAsync();
            return store;
        }
    }
}