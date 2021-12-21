using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class KhachHang
    {
        [Key]
        public Guid KhachHangId { get; set; }

        [MaxLength(50)]
        [Required]
        public string TenKhachHang { get; set; }

        [Phone]
        [MaxLength(10)]
        public string? SoDienThoai { get; set; }

        [MaxLength(50)]
        public string? DiaChi { get; set; }

        [MaxLength(12)]
        public string? Cccd { get; set; }

        [MaxLength(30)]
        public string? STK { get; set; }

        [MaxLength(30)]
        public string? Vung { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

    }
}