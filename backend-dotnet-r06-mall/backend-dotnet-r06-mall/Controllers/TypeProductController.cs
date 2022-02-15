
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace backend_dotnet_r06_mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeProductController : ControllerBase
    {
        private readonly TypeProductServices _service;
        private readonly ILogger<TypeProductController> _logger;

        public TypeProductController(TypeProductServices service, ILogger<TypeProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypeProduct()
        {
            var result = await _service.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> TypeProductRegister([FromBody] TypeProductRequest request)
        {
            var createStore = await _service.CreateLoaiSanPham(request);
            if (createStore is null)
            {
                return BadRequest();
            }
            return Ok("Good");
        }

    }
}
