using System.Threading.Tasks;
using POS_Test_1.DTOs;

namespace POS_Test_1.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<bool> LoginAsync(LoginDto loginDto);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
    }
}
