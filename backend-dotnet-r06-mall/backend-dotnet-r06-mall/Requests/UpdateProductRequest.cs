using System;
namespace backend_dotnet_r06_mall.Requests
{
    public class UpdateProductRequest
    {
        public Guid id { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public int TonKho { get; set; }
        public int DonVi { get; set; }
        public int DonGia { get; set; }
        public Guid LoaiSanPham { get; set; }
    }
}