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

        public async Task<int> TaoDonHang(CartRequest gh, int userId)
        {
            Order dh = new Order
            {
                CreatedDate = DateTime.UtcNow,
                PaymentStatus = gh.isPaid,
                Customer = await _context.Customers.FirstOrDefaultAsync(o => o.CustomerId == userId),
                Amount = 1,
                Address = gh.shippingAddress.address,
                City = gh.shippingAddress.city,
                TotalPrice = gh.totalPrice,
                PaymentType = await _context.PaymentTypes.FirstOrDefaultAsync(o=> o.PaymentName == gh.paymentMethod)
            };

            dh.OrderProduct = new List<OrderProduct>();

            foreach (var item in gh.cartItems)
            {
                OrderProduct dhsp = new OrderProduct
                {
                    Order = dh,
                    Product = await _context.Products.FirstOrDefaultAsync(o => o.ProductId == item.product),
                    Amount = item.qty
                };
                dh.OrderProduct.Add(dhsp);
                var x = await _context.Products.FirstOrDefaultAsync(o => o.ProductId == item.product);
                x.InventoryNumber = x.InventoryNumber - item.qty;
                await _context.SaveChangesAsync();
            }

            dh.OrderStatus = new List<OrderStatus>();
            OrderStatus ttdh = new OrderStatus
            {
                OrderStatusName = "Chờ xác nhận",
                OrderId = dh.OrderId,
                CreatedDate = DateTime.UtcNow,
                Order = dh
            };
            dh.OrderStatus.Add(ttdh);
            await _context.SaveChangesAsync();

            var createResult = await _context.Orders.AddAsync(dh);
            await _context.SaveChangesAsync();
            // return createResult is not null;
            return dh.OrderId;
        }
        public async Task<IList<OrderProduct>> loadDonHang(int donHangId)
        {
            //tra ve gio hang theo ma don hang trong bang DonHangSanPham
            var s = await _context.Orders.Include(q => q.OrderProduct).FirstOrDefaultAsync(q => q.OrderId == donHangId);
            return s.OrderProduct;
            
        }
        // update tinh trang don hang = da thanh toan
        public async Task<bool> thanhToan(int orderId)
        {
            var createdResult = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            createdResult.PaymentStatus = true;
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