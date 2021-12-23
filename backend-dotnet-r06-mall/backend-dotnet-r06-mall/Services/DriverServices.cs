using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Response;
using System;
using System.Linq;

namespace backend_dotnet_r06_mall.Services
{
    public class DriverServices
    {
        private readonly BanHangContext _context;

        public DriverServices(BanHangContext context)
        {
            _context = context;
        }

        public CuaHang FindNearestShop(double ViDo, double KinhDo)
        {
            var shortestStore = _context.CuaHang.AsQueryable().Select(x => new CuaHang
            {
                CuaHangId = x.CuaHangId,
                KinhDo = x.KinhDo,
                ViDo = x.ViDo,
                MoTa = x.MoTa,
                DanhGia = x.DanhGia,
                STK = x.STK,
                TenCuaHang = x.TenCuaHang,
                SoDienThoai = x.SoDienThoai,
            }).ToList().OrderByDescending(x => Calculate(x.ViDo, x.KinhDo, ViDo, KinhDo)).Last();

            return shortestStore;
        }

        private static double Calculate(double lat1, double lon1, double lat2, double lon2)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d;
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2);
            return 12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))); // earth radius 6.372,8‬km x 2 = 12745.6
        }
    }
}
