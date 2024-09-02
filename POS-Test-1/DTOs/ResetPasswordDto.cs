namespace POS_Test_1.DTOs
{
    public class ResetPasswordDto
    {
        public string Token { get; set; } // This property is already expected in your service code
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        // Add this line
        public string ResetToken { get; set; }
    }
}
