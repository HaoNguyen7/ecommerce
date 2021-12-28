using System;

namespace backend_dotnet_r06_mall.Models
{
    public class ViTriNguoiGiaoHang
    {
        public Guid NguoiGiaoId { get; set; }
        public string TenNguoiGiaoHang { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }
        public ViTriNguoiGiaoHang(Guid id, string ten, double kinhdo,double vido)
        {
            NguoiGiaoId = id;
            TenNguoiGiaoHang = ten;
            KinhDo = kinhdo;
            ViDo = vido;
        }
    }
}
