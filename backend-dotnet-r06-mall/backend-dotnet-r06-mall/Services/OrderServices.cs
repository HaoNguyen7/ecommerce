using System;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Services
{
    public class OrderServices
    {
        private readonly BanHangContext _context;


        public OrderServices(BanHangContext context)
        {
            _context = context;
        }

        public async Task<PagedList<DonHang>> GetUserOrder(Guid userId, OrderHistoryRequest query)
        {
            var orders = _context.DonHang.Include(o => o.KhachHang).Where(o => o.KhachHang.KhachHangId.Equals(userId)).OrderByDescending(o => o.ThoiGian);
            return await PagedList<DonHang>.CreateAsync(orders, query.pageIndex, query.pageSize);
        }

        public async Task<DonHang> GetOrderById(Guid orderId)
        {
            return await _context.DonHang.Include(o => o.KhachHang).FirstOrDefaultAsync(p => p.DonHangId == orderId);
        }

    }
}