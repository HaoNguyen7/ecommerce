using System;
namespace backend_dotnet_r06_mall.Requests
{
    public class RegisterProductRequest
    {
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public int TonKho { get; set; }
        public int DonVi { get; set; }
        public int DonGia { get; set; }
        public Guid LoaiSanPham { get; set; }
        public Guid CuaHang { get; set; }
    }
}