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

namespace backend_dotnet_r06_mall.Services
{
    public class CartServices
    {
        private readonly SaleContext _context;


        public CartServices(SaleContext context)
        {
            _context = context;
        }

        public async Task<Guid> TaoDonHang(CartRequest gh, Guid userId)
        {
            Order dh = new Order
            {
                OrderId = new Guid(),
                CreatedDate = DateTime.UtcNow,
                TinhTrangThanhToan = gh.isPaid,
                KhachHang = await _context.KhachHang.FirstOrDefaultAsync(o => o.KhachHangId == userId),
                SoLuong = 1,
                DiaChi = gh.shippingAddress.address,
                ThanhPho = gh.shippingAddress.city,
                TongTien = gh.totalPrice,
                HinhThucThanhToan = await _context.HinhThucThanhToan.FirstOrDefaultAsync(o=> o.TenHTTT == gh.paymentMethod)
            };

            dh.DonHangSanPham = new List<OrderProduct>();

            foreach (var item in gh.cartItems)
            {
                OrderProduct dhsp = new OrderProduct
                {
                    DonHang = dh,
                    SanPham = await _context.SanPham.FirstOrDefaultAsync(o => o.SanPhamId == item.product),
                    SoLuong = item.qty
                };
                dh.DonHangSanPham.Add(dhsp);
                var x = await _context.SanPham.FirstOrDefaultAsync(o => o.SanPhamId == item.product);
                x.TonKho = x.TonKho - item.qty;
                await _context.SaveChangesAsync();
            }

            dh.TinhTrangDonHang = new List<OrderStatus>();
            OrderStatus ttdh = new OrderStatus
            {
                TTDHId = new Guid(),
                TenTinhTrang = "Chờ xác nhận",
                DonHangId = dh.DonHangId,
                NgayThucHien = DateTime.UtcNow,
                DonHang = dh
            };
            dh.TinhTrangDonHang.Add(ttdh);
            await _context.SaveChangesAsync();

            var createResult = await _context.DonHang.AddAsync(dh);
            await _context.SaveChangesAsync();
            // return createResult is not null;
            return dh.DonHangId;
        }
        public async Task<IList<OrderProduct>> loadDonHang(Guid donHangId)
        {
            //tra ve gio hang theo ma don hang trong bang DonHangSanPham
            var s = await _context.DonHang.Include(q => q.DonHangSanPham).FirstOrDefaultAsync(q => q.DonHangId == donHangId);
            return s.DonHangSanPham;
            
        }
        // update tinh trang don hang = da thanh toan
        public async Task<bool> thanhToan(Guid orderId)
        {
            var createdResult = await _context.DonHang.FirstOrDefaultAsync(o => o.DonHangId == orderId);
            createdResult.TinhTrangThanhToan = true;
            await _context.SaveChangesAsync();
            return createdResult is not null;
        }
        // //update dia chi, shipper tong tien cua don hang
        // public async Task<bool> shipping(CartRequest gh, Guid userId)
        // {
        //     var createResult = await _context.DonHang.FirstOrDefault(o => o.DonHangId == donHangId);
        //     return createResult is not null;
        // }
    }
}