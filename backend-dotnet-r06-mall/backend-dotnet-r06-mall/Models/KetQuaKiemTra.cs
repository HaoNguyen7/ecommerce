using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class KetQuaKiemTra
    {
        [Key]
        public Guid KetQuaId { get; set; }
        [MaxLength(50)]
        [Required]
        public string KetQua { get; set; }
        public DateTime NgayKiemTra { get; set; }
    }
}
