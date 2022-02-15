using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend_dotnet_r06_mall.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(50)]
        [Required]
        public string CustomerName { get; set; }

        [Phone]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [MaxLength(12)]
        public string? IdentityNumber { get; set; }

        [MaxLength(30)]
        public string? CardNumber { get; set; }

        [MaxLength(30)]
        public string? Vung { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

    }
}