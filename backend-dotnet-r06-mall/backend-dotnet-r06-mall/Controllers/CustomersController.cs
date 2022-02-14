using Authentication.Configuration;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet_r06_mall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;

        private readonly SaleContext _context;
        private readonly CustomerServices _service;
        private readonly ILogger<ProductController> _logger;

        public CustomersController
        (
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            RoleManager<IdentityRole> roleManager,
            SaleContext context,
            CustomerServices service,
            ILogger<ProductController> logger

        )
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _roleManager = roleManager;
            _context = context;
            _service = service;
            _logger = logger;
        }

        [HttpPut]
        [Route("Change_Information")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<IActionResult> ChangeInfoCustomer([FromBody] UpdateInfoCustomerRequest request)
        {
            Guid KhachHangId = new Guid(User.FindFirst("Id")?.Value);
            var existingUser = await _userManager.FindByIdAsync(KhachHangId.ToString());
            if (KhachHangId != null)
            {
                Customer customer = await _service.UpdateCustomer(request, KhachHangId);
                return Ok(customer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Get_Profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<Customer> GetProfile()
        {
            Guid KhachHangId = new Guid(User.FindFirst("Id")?.Value);
            var existingUser = await _userManager.FindByIdAsync(KhachHangId.ToString());
            Customer kh = await _context.Customers.FindAsync(KhachHangId);
            return kh;

        }


        [HttpGet]
        [Route("ManageAccountByAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Admin)]
        public async Task<List<Customer>> GetUsersAsync()
        {

            return await _context.Customers.ToListAsync();

        }

    }
}

