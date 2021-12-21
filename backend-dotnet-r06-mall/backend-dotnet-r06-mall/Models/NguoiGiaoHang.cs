using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class NguoiGiaoHang
    {
        [Key]
        public Guid NguoiGiaoId { get; set; }

        [MaxLength(50)]
        public string TenNguoiGiaoHang { get; set; }

        [Phone]
        [MaxLength(10)]
        public string SoDienThoai { get; set; }

        [MaxLength(50)]
        public string DiaChi { get; set; }

        [MaxLength(12)]
        public string Cccd { get; set; }

        [MaxLength(30)]
        public string STK { get; set; }

        [MaxLength(30)]
        public string VungHoatDong { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime NgayDangKy { get; set; }

        public ICollection<ThongTinDiDuong> ThongTinDiDuong { get; set; }
        public ICollection<KetQuaKiemTra> KetQuaKiemTra { get; set; }
        public ICollection<DonHang> DonHang { get; set; }
    }
}