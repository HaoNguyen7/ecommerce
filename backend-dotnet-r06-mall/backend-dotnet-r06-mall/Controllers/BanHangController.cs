using System.Collections;
using System.Collections.Generic;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet_r06_mall.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BanHangController : ControllerBase
    {
        BanHangServices _services;
        public BanHangController(BanHangServices services)
        {
            _services = services;
        }

        // For test only
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("/sanpham")]
        public IEnumerable<SanPham> GetAllSanPham()
        {
            return _services.GetAllSanPham();
        }
    }
}