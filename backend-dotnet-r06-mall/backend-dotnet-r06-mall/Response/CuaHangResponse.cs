using backend_dotnet_r06_mall.Models;
using System;

namespace backend_dotnet_r06_mall.Response
{
    public class CuaHangResponse
    {
        public int CuaHangId { get; set; }
        public string TenCuaHang { get; set; }
        public string MoTa { get; set; }
        public string DanhGia { get; set; }
        public string SoDienThoai { get; set; }
        public string STK { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }
        public string DiaChi { get; set; }
        public bool TinhTrang { get; set; }

        public string GiayPhepKinhDoanh { get; set; }
        public CuaHangResponse(Store cuaHang)
        {
            CuaHangId = cuaHang.StoreId;
            TenCuaHang = cuaHang.StoreName;
            MoTa = cuaHang.Description;
            DanhGia = cuaHang.Comment;
            SoDienThoai = cuaHang.PhoneNumber;
            DiaChi = cuaHang.DiaChi;
            TinhTrang = cuaHang.Status;
        }
    }
}
