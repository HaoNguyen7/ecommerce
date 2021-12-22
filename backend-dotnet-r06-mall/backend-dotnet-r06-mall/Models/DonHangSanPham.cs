using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class DonHangSanPham
    {
        public Guid DonHangId { get; set; }
        [JsonIgnore]
        public DonHang DonHang { get; set; }
        public Guid SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }

    }
}