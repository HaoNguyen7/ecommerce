using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class LoaiSanPham
    {
        [Key]
        public Guid LoaiId { get; set; }
        [MaxLength(50)]
        public string Ten { get; set; }
    }
}