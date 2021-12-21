using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class ThongTinDiDuong
    {
        [Key]
        public Guid TTTDId { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgayHetHan { get; set; }
    }
}