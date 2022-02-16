using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public int CategoriId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
