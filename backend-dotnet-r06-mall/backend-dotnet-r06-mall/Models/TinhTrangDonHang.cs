using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class TinhTrangDonHang
    {
        [Key]
        public Guid TTDHId { get; set; }
        [MaxLength(30)]
        public string TenTinhTrang { get; set; }
        public string GhiChu { get; set; }
        [Required]
        public DateTime NgayThucHien { get; set; }

        public DonHang DonHang { get; set; }
    }
}