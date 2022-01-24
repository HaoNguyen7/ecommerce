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
        private readonly BanHangContext _context;
        private readonly ILogger<OrderServices> _logger;
        public OrderServices(BanHangContext context, ILogger<OrderServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<DonHang>> GetUserOrder(Guid userId, OrderHistoryRequest query)
        {
            var orders = _context.DonHang.Include(o => o.KhachHang).Where(o => o.KhachHang.KhachHangId.Equals(userId)).OrderByDescending(o => o.ThoiGian);
            return await PagedList<DonHang>.CreateAsync(orders, query.pageIndex, query.pageSize);
        }

        public async Task<DonHang> GetOrderById(Guid orderId)
        {
            return await _context.DonHang.Include(o => o.KhachHang).Include(o => o.DonHangSanPham).Include(o => o.SanPham).FirstOrDefaultAsync(p => p.DonHangId == orderId);
        }

        public async Task<TinhTrangDonHang> GetOrderLastestState(Guid orderId)
        {
            return await _context.TinhTrangDonHang.AsNoTracking().OrderByDescending(k => k.NgayThucHien).FirstOrDefaultAsync(o => o.DonHang.DonHangId == orderId);
        }

        public async Task<Boolean> UserCancelOrder(DonHang order)
        {
            var latestState = await GetOrderLastestState(order.DonHangId);

            if (latestState.TenTinhTrang == OrderStateConstants.ChoXacNhan || latestState.TenTinhTrang == OrderStateConstants.DangXuLy)
            {
                TinhTrangDonHang tinhTrangDonHang = new TinhTrangDonHang()
                {
                    TTDHId = new Guid(),
                    TenTinhTrang = OrderStateConstants.KhachHuyDon,
                    NgayThucHien = DateTime.UtcNow,
                    DonHang = order
                };

                var AddResult = _context.TinhTrangDonHang.AddAsync(tinhTrangDonHang);
                await _context.SaveChangesAsync();

                return AddResult.IsCompletedSuccessfully;
            }
            return false;
        }

        public async Task<IList<DonHangSanPham>> GetOrderDriverByID(Guid orderId)
        {
            return await _context.DonHangSanPham.Include(o => o.SanPham).Where(p => p.DonHangId == orderId).ToListAsync();
        }

    }
}