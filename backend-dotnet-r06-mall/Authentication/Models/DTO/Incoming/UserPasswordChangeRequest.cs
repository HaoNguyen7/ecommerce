using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Models.DTO.Incoming
{
    public class UserPasswordChangRequest
    {
        [Required]
        [PasswordPropertyText]
        public string oldPassword { get; set; }
        [Required]
        [PasswordPropertyText]
        public string newPassword { get; set; }
    }
}