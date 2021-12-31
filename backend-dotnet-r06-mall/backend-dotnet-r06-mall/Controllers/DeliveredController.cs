using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend_dotnet_r06_mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveredController : ControllerBase
    {
        private readonly DeliveredServices _service;
        private readonly ILogger<DeliveredController> _logger;

        public DeliveredController(DeliveredServices service, ILogger<DeliveredController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("history")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.TaiXe)]
        public async Task<IActionResult> GetDeliveredOrders([FromQuery] OrderDeliveredRequest query)
        {
            Guid shipperId = new Guid(User.FindFirst("Id")?.Value);
            var orders = await _service.GetDeliveredOrder(shipperId, query);
            return Ok(new PagedListResponse<DonHang>(orders));
        }

        [HttpGet("{orderId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.TaiXe)]
        public async Task<IActionResult> GetDeliveredOrderById(Guid orderId)
        {
            Guid shipperId = new Guid(User.FindFirst("Id")?.Value);
            var order = await _service.GetDeliveredById(orderId);
            if (order is null)
            {
                return NotFound();
            }

            if (order.NguoiGiaoHang is null || !order.NguoiGiaoHang.NguoiGiaoId.Equals(shipperId))
            {
                return Forbid();
            }

            return Ok(order);
        }
    }
}