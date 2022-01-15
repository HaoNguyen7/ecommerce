using System;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend_dotnet_r06_mall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly StoreService _service;

        public StoreController(ILogger<OrderController> logger,
             StoreService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<IActionResult> StoreRegister([FromBody] RegisterStoreRequest request)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);

            var createStore = await _service.CreateStore(userId, request);
            if (createStore is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Route("active-store")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Admin)]
        public async Task<IActionResult> ActiveShop([FromQuery] ActiveStoreRequest query)
        {
            CuaHang cuaHang = await _service.ActiveStore(query);
            return Ok(cuaHang);
        }
        // [HttpPost]
        // [Route("register")]
        // // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        // public async Task<IActionResult> StoreRegister([FromBody] RegisterStoreRequest request)
        // {
        //     Guid userId = new Guid(User.FindFirst("Id")?.Value);

        //     var createStore = await _service.CreateStore(userId, request);
        //     if (createStore is null)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok();
        // }

    }
}