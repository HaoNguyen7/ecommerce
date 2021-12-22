using System.ComponentModel.DataAnnotations;

namespace Authentication.Models.DTO.Incoming
{
    public class UserLoginRequestDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}