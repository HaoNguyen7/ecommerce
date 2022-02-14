using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet_r06_mall.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string PaymentName { get; set; }
    }
}