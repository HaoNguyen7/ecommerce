using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet_r06_mall.Models
{
    public class CuaHang
    {
        public Guid CuaHangId { get; set; }

        [Required]
        [MaxLength(2147483645)]
        public string TenCuaHang { get; set; }
        [MaxLength(2147483645)]
        public string MoTa { get; set; }
        [MaxLength(2147483645)]
        public string? DanhGia { get; set; }
        [Phone]
        [MaxLength(20)]
        [Required]
        public string SoDienThoai { get; set; }
        [MaxLength(30)]
        public string STK { get; set; }
        public Boolean TinhTrang { get; set; }

        [MaxLength(100)]
        public string MaSoThue { get; set; }
        [MaxLength(2147483645)]
        public string GiayPhepKinhDoanh { get; set; }

        [MaxLength(2147483645)]
        public string DiaChi { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }

        public Guid UserId { get; set; }
    }
}