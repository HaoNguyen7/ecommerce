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
        public double KhoangCach { get; set; }
    }
}
