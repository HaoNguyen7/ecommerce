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
            var orders = _context.DonHang.Include(o => o.KhachHang).Where(o => o.KhachHang.KhachHangId.Equals(userId)).OrderByDescending(o => o.ThoiGian);
            return await PagedList<Order>.CreateAsync(orders, query.pageIndex, query.pageSize);
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            return await _context.DonHang.Include(o => o.KhachHang).Include(o => o.DonHangSanPham).Include(o => o.SanPham).FirstOrDefaultAsync(p => p.DonHangId == orderId);
        }

        public async Task<OrderStatus> GetOrderLastestState(Guid orderId)
        {
            return await _context.TinhTrangDonHang.AsNoTracking().OrderByDescending(k => k.NgayThucHien).FirstOrDefaultAsync(o => o.DonHang.DonHangId == orderId);
        }

        public async Task<Boolean> UserCancelOrder(Order order)
        {
            var latestState = await GetOrderLastestState(order.DonHangId);

            if (
                latestState.TenTinhTrang != OrderStateConstants.DangVanChuyen && latestState.TenTinhTrang != OrderStateConstants.GiaoHangThanhCong && latestState.TenTinhTrang != OrderStateConstants.KhachHuyDon)
            {
                OrderStatus tinhTrangDonHang = new OrderStatus()
                {
                    TTDHId = new Guid(),
                    TenTinhTrang = OrderStateConstants.KhachHuyDon,
                    NgayThucHien = DateTime.UtcNow,
                    GhiChu = "Khách huỷ đơn",
                    DonHang = order
                };

                var AddResult = _context.TinhTrangDonHang.AddAsync(tinhTrangDonHang);
                await _context.SaveChangesAsync();

                return AddResult.IsCompletedSuccessfully;
            }
            return false;
        }

        public async Task<IList<OrderProduct>> GetOrderDriverByID(Guid orderId)
        {
            return await _context.DonHangSanPham.Include(o => o.SanPham).Where(p => p.DonHangId == orderId).ToListAsync();
        }

    }
}