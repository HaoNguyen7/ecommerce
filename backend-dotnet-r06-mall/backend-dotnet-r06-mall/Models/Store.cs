using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet_r06_mall.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [MaxLength(2147483645)]
        public string StoreName { get; set; }
        [MaxLength(2147483645)]
        public string Description { get; set; }
        [MaxLength(2147483645)]
        public string? Comment { get; set; }
        [Phone]
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public Boolean Status { get; set; }
        public string DiaChi { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}