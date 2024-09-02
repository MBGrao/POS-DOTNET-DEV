using System.Net.Mail;
using System.Threading.Tasks;
using POS_Test_1.Interfaces;
using POS_Test_1.Models;

namespace POS_Test_1.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendResetPasswordEmail(User user)
        {
            // Implement email sending logic
            // Example:
            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                Subject = "Reset Your Password",
                Body = $"Click this link to reset your password: http://example.com/reset?token={user.ResetToken}",
                IsBodyHtml = true
            };
            mailMessage.To.Add(user.Email);

            using (var smtpClient = new SmtpClient("smtp.example.com"))
            {
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
