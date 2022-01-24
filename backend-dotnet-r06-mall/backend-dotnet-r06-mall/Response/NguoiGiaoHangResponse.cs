using backend_dotnet_r06_mall.Models;
using System;

namespace backend_dotnet_r06_mall.Response
{
    public class NguoiGiaoHangResponse
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

        public NguoiGiaoHangResponse(NguoiGiaoHang nguoiGiaoHang)
        {
            NguoiGiaoId = nguoiGiaoHang.NguoiGiaoId;
            TenNguoiGiaoHang = nguoiGiaoHang.TenNguoiGiaoHang;
            SoDienThoai = nguoiGiaoHang.SoDienThoai;
            DiaChi = nguoiGiaoHang.DiaChi;
            VungHoatDong = nguoiGiaoHang.VungHoatDong;
            NgayDangKy = nguoiGiaoHang.NgayDangKy;
            Cccd = nguoiGiaoHang.Cccd;
        }
    }
}
