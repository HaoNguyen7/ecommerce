using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [MaxLength(2147483645)]
        public string Description { get; set; }
        [Required]
        public int InventoryNumber { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public string Unit { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Category Category { get; set; }

        public Store Store { get; set; }
        [MaxLength(2147483645)]
        public string Image { get; set; }

        [MaxLength(2147483645)]
        public string Origin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Order { get; set; }
        [JsonIgnore]
        public List<OrderProduct> OrderProduct { get; set; }

    }
}