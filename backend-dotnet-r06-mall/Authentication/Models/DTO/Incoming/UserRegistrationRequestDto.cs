using System.ComponentModel.DataAnnotations;

namespace Authentication.Models.DTO.Incoming
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string TenKhachHang { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}