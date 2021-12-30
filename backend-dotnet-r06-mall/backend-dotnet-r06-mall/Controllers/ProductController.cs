using System;
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
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductServices service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList([FromQuery] ProductListRequest query)
        {
            PagedList<SanPham> listProducts = await _service.GetProducts(query);
            return Ok(new PagedListResponse<SanPham>(listProducts));
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetPoducDetail(Guid productId)
        {
            var product = await _service.GetProductDetail(productId);
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

    }
}