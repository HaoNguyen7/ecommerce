using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class DonHang
    {
        public Guid DonHangId { get; set; }

        public DateTime ThoiGian { get; set; }

        [Required]
        public bool TinhTrangThanhToan { get; set; }

        public string? DanhGia { get; set; }

        [Required]
        public int? SoLuong { get; set; }

        public HinhThucThanhToan HinhThucThanhToan { get; set; }

        public KhachHang KhachHang { get; set; }

        public NguoiGiaoHang NguoiGiaoHang { get; set; }

        public List<TinhTrangDonHang> TinhTrangDonHang { get; set; }

        [JsonIgnore]
        public virtual ICollection<SanPham> SanPham { get; set; }
        public List<DonHangSanPham> DonHangSanPham { get; set; }
    }

}