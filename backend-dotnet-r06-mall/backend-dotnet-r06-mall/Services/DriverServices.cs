using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet_r06_mall.Services
{
    public class DriverServices
    {
        private readonly BanHangContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DriverServices(BanHangContext context, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

        public NguoiGiaoHang FindNearestShipper(double ViDo, double KinhDo)
        {
            //Fake shipper location
            var arrayProducts = new ViTriNguoiGiaoHang[]                
            {
                new ViTriNguoiGiaoHang(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"),"Nguyen Van A",10.7,107.3),
                new ViTriNguoiGiaoHang(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857708"),"Nguyen Van B",10.9,107.55),
                new ViTriNguoiGiaoHang(new Guid("9D2B0228-4D0D-4C23-8B49-01A698857707"),"Nguyen Van C",10.33,107.22),
            };

            var driver = arrayProducts.OrderByDescending(x => Calculate(x.ViDo, x.KinhDo, ViDo, KinhDo)).Last();
            var driverInfo = _context.NguoiGiaoHang.Find(driver.NguoiGiaoId);
            
            return driverInfo;
        }

        public async Task<NguoiGiaoHang> RegisterDriverAsync(RegisterDriverRequest request)
        {
            var existEmail = _context.NguoiGiaoHang.Any(x => x.Email == request.Email);
            if (existEmail)
            {
                throw new Exception("Your email already exist");
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.AddToRoleAsync(existingUser, RoleConstants.TaiXe);
            var driver = new NguoiGiaoHang
            {
                NguoiGiaoId = new Guid(),
                TenNguoiGiaoHang = request.TenNguoiGiaoHang,
                SoDienThoai = request.SoDienThoai,
                DiaChi = request.DiaChi,
                Cccd = request.Cccd,
                STK = request.STK,
                VungHoatDong = request.VungHoatDong,
                Email = request.Email,
                NgayDangKy = DateTime.Now
            };
            _context.NguoiGiaoHang.Add(driver);
            _context.SaveChanges();

            return driver;
        }

        private static double Calculate(double lat1, double lon1, double lat2, double lon2)
        {
            double rad(double angle) => angle * 0.017453292519943295769236907684886127d;
            double havf(double diff) => Math.Pow(Math.Sin(rad(diff) / 2d), 2);
            return 12745.6 * Math.Asin(Math.Sqrt(havf(lat2 - lat1) + Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * havf(lon2 - lon1))); // earth radius 6.372,8‬km x 2 = 12745.6
        }

        public async Task<NguoiGiaoHang> GetNguoiGiaoHangById(Guid shipperId)
        {
            return await _context.NguoiGiaoHang.AsNoTracking().Include(o => o.DonHang).FirstOrDefaultAsync(o => o.NguoiGiaoId.Equals(shipperId));
        }
    }
}
