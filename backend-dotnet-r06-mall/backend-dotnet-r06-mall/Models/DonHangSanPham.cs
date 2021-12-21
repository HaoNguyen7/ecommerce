using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet_r06_mall.Models
{
    public class DonHangSanPham
    {
        public Guid DonHangId { get; set; }
        public DonHang DonHang { get; set; }
        public Guid SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }

    }
}