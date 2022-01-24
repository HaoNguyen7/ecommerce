using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet_r06_mall.Services
{
    public class CustomerServices
    {
        private readonly BanHangContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public CustomerServices(UserManager<IdentityUser> userManager, BanHangContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<KhachHang> UpdateCustomer(UpdateInfoCustomerRequest request, Guid KhachHangId)
        {
            KhachHang customer = _context.KhachHang.Find(KhachHangId);
            if (customer == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(request.TenKhachHang))
            {
                customer.TenKhachHang = request.TenKhachHang;
            }
            if (!String.IsNullOrEmpty(request.SoDienThoai))
            {
                customer.SoDienThoai = request.SoDienThoai;
            }

            if (request.DiaChi != "")
            {
                customer.DiaChi = request.DiaChi;
            }

            if (request.Cccd != "")
            {
                customer.Cccd = request.Cccd;
            }
            if (request.STK != "")
            {
                customer.STK = request.STK;
            }
            if (request.Vung != "")
            {
                customer.Vung = request.Vung;
            }
            await _context.SaveChangesAsync();
            return customer;
        }

    }
}
