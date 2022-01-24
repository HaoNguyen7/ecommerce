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
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _service;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderServices service, ILogger<OrderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("history")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<IActionResult> GetUserOrders([FromQuery] OrderHistoryRequest query)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var orders = await _service.GetUserOrder(userId, query);
            return Ok(orders);
        }

        [HttpGet("view/{orderId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach + "," + RoleConstants.TaiXe)]
        public async Task<IActionResult> GetUserOrderById(Guid orderId)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var order = await _service.GetOrderById(orderId);
            if (order is null)
            {
                return NotFound();
            }

            if (order.KhachHang is null || !order.KhachHang.KhachHangId.Equals(userId))
            {
                return Forbid();
            }

            return Ok(order);
        }

        [HttpGet("view/driver/{orderId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.TaiXe)]
        public async Task<IActionResult> GetDriverOrderById(Guid orderId)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var order = await _service.GetOrderDriverByID(orderId);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpDelete("tracking/{orderId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<IActionResult> CancelUserOrder(Guid orderId)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var order = await _service.GetOrderById(orderId);
            if (order is null)
            {
                return NotFound();
            }

            if (order.KhachHang is null || !order.KhachHang.KhachHangId.Equals(userId))
            {
                return Forbid();
            }

            Boolean addResult = await _service.UserCancelOrder(order);
            if (addResult)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("tracking/{orderId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = RoleConstants.Khach)]
        public async Task<IActionResult> TrackUserOrder(Guid orderId)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var order = await _service.GetOrderById(orderId);
            if (order is null)
            {
                return NotFound();
            }

            if (order.KhachHang is null || !order.KhachHang.KhachHangId.Equals(userId))
            {
                return Forbid();
            }

            Boolean addResult = await _service.UserCancelOrder(order);
            if (addResult)
            {
                return NoContent();
            }
            else
            {
                return Forbid();
            }
        }
    }
}