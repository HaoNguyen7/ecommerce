using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class SanPham
    {
        [Key]
        public Guid SanPhamId { get; set; }
        [MaxLength(2147483645)]
        [Required]
        public string TenSanPham { get; set; }

        [MaxLength(2147483645)]
        public string MoTa { get; set; }
        [Required]
        public int TonKho { get; set; }
        [Required]
        public int DonGia { get; set; }
        [Required]
        public string DonVi { get; set; }

        [Required]
        public DateTime NgayDang { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }

        public CuaHang CuaHang { get; set; }

        [JsonIgnore]
        public virtual ICollection<DonHang> DonHang { get; set; }
        [JsonIgnore]
        public List<DonHangSanPham> DonHangSanPham { get; set; }

    }
}