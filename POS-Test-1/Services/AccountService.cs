using System.Threading.Tasks;
using POS_Test_1.Interfaces;
using POS_Test_1.DTOs;
using POS_Test_1.Models;
using POS_Test_1.Helpers;
using Microsoft.AspNetCore.Identity;
namespace POS_Test_1.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IEmailService _emailService;
      //  private readonly PasswordHasherService _passwordHasher;
        private readonly IPasswordHasherService _passwordHasher;
        public AccountService(
            IUserRepository userRepository,
            ITokenRepository tokenRepository,
            IEmailService emailService,
            PasswordHasherService passwordHasher)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PasswordHash = _passwordHasher.HashPassword(registerDto.Password),
                ResetToken = string.Empty // or provide a default value
            };

            return await _userRepository.CreateUserAsync(user);
        }


        public async Task<bool> LoginAsync(LoginDto loginDto)
        {
            // Implement login logic
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return false;
            }

            // Generate token or handle login success
            return true;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            // Implement forgot password logic
            var user = await _userRepository.GetUserByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return false;
            }

            // Send email with reset link
            return await _emailService.SendResetPasswordEmail(user);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            // Implement reset password logic
            var user = await _userRepository.GetUserByResetTokenAsync(resetPasswordDto.Token);
            if (user == null)
            {
                return false;
            }

            user.PasswordHash = _passwordHasher.HashPassword(resetPasswordDto.NewPassword);
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            // Implement change password logic
            var user = await _userRepository.GetUserByEmailAsync(changePasswordDto.Email);
            if (user == null || !_passwordHasher.VerifyPassword(changePasswordDto.OldPassword, user.PasswordHash))
            {
                return false;
            }

            user.PasswordHash = _passwordHasher.HashPassword(changePasswordDto.NewPassword);
            return await _userRepository.UpdateUserAsync(user);
        }
    }
}
