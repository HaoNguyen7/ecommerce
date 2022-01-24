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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using backend_dotnet_r06_mall.Contants;

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
            return Ok(listProducts);
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
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> ProductRegister([FromBody] RegisterProductRequest request)
        {

            var createStore = await _service.CreateProduct(request);
            if (createStore is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            SanPham product = await _service.UpdateProduct(request);

            if (product == null)
            {
                return BadRequest("Wrong id");
            }
            return Ok(product);
        }

        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromBody] RemoveProductRequest request)
        {
            bool result = await _service.RemoveProduct(request);

            if (!result)
            {
                return BadRequest("Wrong id");
            }
            return Ok(result);
        }
    }
}