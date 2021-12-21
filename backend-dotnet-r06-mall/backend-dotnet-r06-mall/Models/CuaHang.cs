using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet_r06_mall.Models
{
    public class CuaHang
    {
        public Guid CuaHangId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenCuaHang { get; set; }
        [MaxLength(255)]
        public string MoTa { get; set; }
        [MaxLength(50)]
        public string? DanhGia { get; set; }
        [Phone]
        [MaxLength(10)]
        [Required]
        public string SoDienThoai { get; set; }
        [MaxLength(30)]
        public string STK { get; set; }

        [Column(TypeName = "decimal(18,10)")]
        public decimal KinhDo { get; set; }
        [Column(TypeName = "decimal(18,10)")]
        public decimal ViDo { get; set; }
    }
}