using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class SanPham
    {
        [Key]
        public Guid SanPhamId { get; set; }
        [MaxLength(50)]
        [Required]
        public string TenSanPham { get; set; }

        public string MoTa { get; set; }
        [Required]
        public int TonKho { get; set; }
        [Required]
        public int DonGia { get; set; }
        [Required]
        public int DonVi { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }

        public CuaHang CuaHang { get; set; }

        public virtual ICollection<DonHang> DonHang { get; set; }
        public List<DonHangSanPham> DonHangSanPham { get; set; }

    }
}