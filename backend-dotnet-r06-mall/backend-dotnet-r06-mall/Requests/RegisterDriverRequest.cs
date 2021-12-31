using System;

namespace backend_dotnet_r06_mall.Requests
{
    public class RegisterDriverRequest
    {
        public Guid NguoiGiaoId { get; set; }
        public string TenNguoiGiaoHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Cccd { get; set; }
        public string STK { get; set; }
        public string VungHoatDong { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
    }
}
