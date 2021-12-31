using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend_dotnet_r06_mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartServices _service;
        private readonly ILogger<CartController> _logger;

        public CartController(CartServices service, ILogger<CartController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetProduct([FromQuery] ProductListRequest query)
        // {
        //     PagedList<SanPham> listProducts = await _service.GetProducts(query);
        //     return Ok(new PagedListResponse<SanPham>(listProducts));
        // }

        [HttpPost]
        public async Task<IActionResult> ThemHangVaoGio(int donHangId)
        {
            return Ok(new )
        }

        [HttpGet("Cart/{userId}")]
        public async Task<IActionResult> LoadGioHang(int donHangId)
        {
            IList<DonHangSanPham> ds = await 
        }
    }
}