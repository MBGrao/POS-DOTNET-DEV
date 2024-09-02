namespace POS_Test_1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }  // Ensure this property exists
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ResetToken { get; set; }  // Ensure this property exists
    }
}
