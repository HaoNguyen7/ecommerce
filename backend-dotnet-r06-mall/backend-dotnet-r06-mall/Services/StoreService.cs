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
                StoreName = request.Name,
                Description = request.Description,
                PhoneNumber = request.PhoneNumber,
                DiaChi = request.Address,
                Status = false,
            };

            var createResult = await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return createResult;
        }

        public async Task<List<Store>> GetInactiveStores(GetInactiveStoreRequest query)
        {
            var stores = from s in _context.Stores 
                         select s;
            stores = stores.Where(s => s.Status.Equals(false));
            
            var res = await stores.AsNoTracking().ToListAsync();
            return res;
        }

        public Task<Store> GetInfoStore(GetStoreByIdRequest query)
        {
            var store = _context.Stores.Find(query.id);
            return Task.FromResult(store);
        }

        public async Task<Store> ActiveStore(ActiveStoreRequest query)
        {
            var store = _context.Stores.Find(query.id);
            store.Status = true;
            await _context.SaveChangesAsync();
            return store;
        }
    }
}