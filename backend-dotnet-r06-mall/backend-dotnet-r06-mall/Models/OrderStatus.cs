using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        [MaxLength(30)]
        public string OrderStatusName { get; set; }
        public string Note { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}