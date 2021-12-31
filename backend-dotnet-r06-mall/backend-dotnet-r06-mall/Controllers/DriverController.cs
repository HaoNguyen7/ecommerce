using System;
using System.Threading.Tasks;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Query;
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
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly DriverServices _driverServices;
        public DriverController(ILogger<DriverController> logger, DriverServices driverServices)
        {
            _logger = logger;
            _driverServices = driverServices;
        }

        [Authorize(Roles = RoleConstants.TaiXe)]
        [HttpGet("shortest_shop")]
        public ActionResult<CuaHangResponse> Get([FromQuery] SearchShortestStoreQuery query)
        {
            return Ok(new CuaHangResponse(_driverServices.FindNearestShop(query.ViDo, query.KinhDo)));
        }

        [Authorize(Roles = RoleConstants.TaiXe)]
        [HttpGet("shortest_shipper")]
        public ActionResult<NguoiGiaoHangResponse> GetShortestShipper([FromQuery] SearchShortestStoreQuery query)
        {
            return Ok(new NguoiGiaoHangResponse(_driverServices.FindNearestShipper(query.ViDo,query.KinhDo)));
        }

        [HttpPost("register_driver")]
        public async Task<ActionResult<NguoiGiaoHangResponse>> RegisterDriver([FromBody] RegisterDriverRequest request)
        {
            return Ok(new NguoiGiaoHangResponse(await _driverServices.RegisterDriverAsync(request)));
        }

        [HttpGet]
        [Route("{shipperId}")]
        public async Task<IActionResult> GetNguoiGiaoHangById(Guid shipperId)
        {
            var shipper = await _driverServices.GetNguoiGiaoHangById(shipperId);
            if (shipper is null)
            {
                return NotFound();
            }
            return Ok(shipper);
        }
    }
}
