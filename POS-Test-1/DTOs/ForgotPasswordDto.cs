using System.ComponentModel.DataAnnotations;

namespace POS_Test_1.DTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
