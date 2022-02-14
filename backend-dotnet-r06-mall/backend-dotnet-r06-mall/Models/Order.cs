using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public bool PaymentStatus { get; set; }

        public string? Comment { get; set; }

        [Required]
        public int? Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public Customer Customer { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; } 
        public string District { get; set; }
        public string Street { get; set; }
        public string NumberAddress { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderStatus> OrderStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Product { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
    }

}