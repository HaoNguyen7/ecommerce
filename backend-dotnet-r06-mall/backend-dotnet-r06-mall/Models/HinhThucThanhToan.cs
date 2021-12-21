using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class HinhThucThanhToan
    {
        [Key]
        public Guid HinhThucId { get; set; }
        [MaxLength(50)]
        public string TenHTTT { get; set; }
    }
}