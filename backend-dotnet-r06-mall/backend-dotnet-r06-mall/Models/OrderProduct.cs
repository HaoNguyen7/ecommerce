using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_dotnet_r06_mall.Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

    }
}