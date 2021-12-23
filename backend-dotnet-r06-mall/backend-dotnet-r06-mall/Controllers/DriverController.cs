using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Query;
using backend_dotnet_r06_mall.Response;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace backend_dotnet_r06_mall.Controllers
{
    [Authorize(Roles = RoleConstants.TaiXe)]
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
   
        [HttpGet]
        public ActionResult<CuaHangResponse> Get([FromQuery] SearchShortestStoreQuery query)
        {         
            return Ok(new CuaHangResponse(_driverServices.FindNearestShop(query.ViDo, query.KinhDo)));
        }
    }
}
