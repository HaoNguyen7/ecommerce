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
        private readonly SaleContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public CustomerServices(UserManager<IdentityUser> userManager, SaleContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Customer> UpdateCustomer(UpdateInfoCustomerRequest request, Guid KhachHangId)
        {
            Customer customer = _context.Customers.Find(KhachHangId);
            if (customer == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(request.TenKhachHang))
            {
                customer.CustomerName = request.TenKhachHang;
            }
            if (!String.IsNullOrEmpty(request.SoDienThoai))
            {
                customer.PhoneNumber = request.SoDienThoai;
            }

            if (request.DiaChi != "")
            {
                customer.Address = request.DiaChi;
            }

            if (request.Cccd != "")
            {
                customer.IdentityNumber = request.Cccd;
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
