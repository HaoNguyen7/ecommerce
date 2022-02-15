using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend_dotnet_r06_mall.Services
{
    public class OrderServices
    {
        private readonly SaleContext _context;
        private readonly ILogger<OrderServices> _logger;
        public OrderServices(SaleContext context, ILogger<OrderServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<Order>> GetUserOrder(Guid userId, OrderHistoryRequest query)
        {
            var orders = _context.Orders.Include(o => o.Customer).Where(o => o.Customer.CustomerId.Equals(userId)).OrderByDescending(o => o.CreatedDate);
            return await PagedList<Order>.CreateAsync(orders, query.pageIndex, query.pageSize);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders.Include(o => o.Customer).Include(o => o.OrderProduct).Include(o => o.Product).FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task<OrderStatus> GetOrderLastestState(int orderId)
        {
            return await _context.OrderStatuses.AsNoTracking().OrderByDescending(k => k.CreatedDate).FirstOrDefaultAsync(o => o.Order.OrderId == orderId);
        }

        public async Task<Boolean> UserCancelOrder(Order order)
        {
            var latestState = await GetOrderLastestState(order.OrderId);

            if (
                latestState.OrderStatusName != OrderStateConstants.DangVanChuyen && latestState.OrderStatusName != OrderStateConstants.GiaoHangThanhCong && latestState.OrderStatusName != OrderStateConstants.KhachHuyDon)
            {
                OrderStatus tinhTrangDonHang = new OrderStatus()
                {
                    OrderStatusName = OrderStateConstants.KhachHuyDon,
                    CreatedDate = DateTime.UtcNow,
                    Note = "Khách huỷ đơn",
                    Order = order
                };

                var AddResult = _context.OrderStatuses.AddAsync(tinhTrangDonHang);
                await _context.SaveChangesAsync();

                return AddResult.IsCompletedSuccessfully;
            }
            return false;
        }

        public async Task<IList<OrderProduct>> GetOrderDriverByID(int orderId)
        {
            return await _context.OrderProducts.Include(o => o.Product).Where(p => p.OrderId == orderId).ToListAsync();
        }

    }
}