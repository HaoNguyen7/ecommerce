using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Query;
using backend_dotnet_r06_mall.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend_dotnet_r06_mall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly BanHangContext _dbContextModel;
        public DriverController(ILogger<DriverController> logger, BanHangContext dbContextModel)
        {
            _logger = logger;
            _dbContextModel = dbContextModel;
        }
   
        [HttpGet]
        public ActionResult<CuaHangResponse> Get([FromQuery] SearchShortestStoreQuery query)
        {
            var listStore = _dbContextModel.CuaHang.AsQueryable().Select(x => new CuaHangResponse { 
                CuaHangId = x.CuaHangId,
                KinhDo = x.KinhDo,
                ViDo = x.ViDo,
                MoTa = x.MoTa,
                DanhGia = x.DanhGia,
                STK = x.STK,
                TenCuaHang = x.TenCuaHang,
                SoDienThoai = x.SoDienThoai,
                KhoangCach = Calculate(x.ViDo,x.KinhDo,query.ViDo,query.KinhDo)
            }).ToList();

            var shortestStore = listStore.OrderByDescending(x => x.KhoangCach).Last();

            return Ok(shortestStore);
        }

        private static double Calculate(double lat1, double lon1, double lat2, double lon2)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d; 
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2); 
            return 12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))); // earth radius 6.372,8‬km x 2 = 12745.6
        }
    }
}
