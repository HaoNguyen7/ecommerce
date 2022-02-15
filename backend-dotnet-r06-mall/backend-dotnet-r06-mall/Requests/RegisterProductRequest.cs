using System;
namespace backend_dotnet_r06_mall.Requests
{
    public class RegisterProductRequest
    {
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public int TonKho { get; set; }
        public string DonVi { get; set; }
        public int DonGia { get; set; }
        public int LoaiSanPham { get; set; }
        public int CuaHang { get; set; }
        public string HinhMinhHoa  { get; set; }
        public string NguonGoc { get; set; }
    }
}