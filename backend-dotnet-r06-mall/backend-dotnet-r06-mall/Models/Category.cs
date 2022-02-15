using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}