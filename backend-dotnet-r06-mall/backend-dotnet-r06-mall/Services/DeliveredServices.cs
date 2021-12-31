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
    public class DeliveredServices
    {
     private readonly BanHangContext _context;

     public DeliveredServices(BanHangContext context)
     {
         _context = context;
     }

     public async Task<PagedList<DonHang>> GetDeliveredOrder(Guid shipperId, OrderDeliveredRequest query)
     {
         var orders = _context.DonHang.Include(o => o.NguoiGiaoHang).Where(
             o => o.NguoiGiaoHang.NguoiGiaoId.Equals(shipperId)).OrderByDescending(o=>o.ThoiGian);
        return await PagedList<DonHang>.CreateAsync(orders, query.pageIndex, query.pageSize);
     }

     public async Task<DonHang> GetDeliveredById(Guid orderId)
     {
         return await _context.DonHang.Include(o=>o.NguoiGiaoHang).FirstOrDefaultAsync(p=>p.DonHangId==orderId);
     }

    }
}