using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}