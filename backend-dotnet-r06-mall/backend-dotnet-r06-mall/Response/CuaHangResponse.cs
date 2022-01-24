using backend_dotnet_r06_mall.Models;
using System;

namespace backend_dotnet_r06_mall.Response
{
    public class CuaHangResponse
    {
        public Guid CuaHangId { get; set; }
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
        public CuaHangResponse(CuaHang cuaHang)
        {
            CuaHangId = cuaHang.CuaHangId;
            TenCuaHang = cuaHang.TenCuaHang;
            MoTa = cuaHang.MoTa;
            DanhGia = cuaHang.DanhGia;
            SoDienThoai = cuaHang.SoDienThoai;
            STK = cuaHang. STK;
            DiaChi = cuaHang.DiaChi;
            TinhTrang = cuaHang.TinhTrang;
            KinhDo = cuaHang.KinhDo;
            ViDo = cuaHang.ViDo;
            GiayPhepKinhDoanh = cuaHang.GiayPhepKinhDoanh;
        }
    }
}
