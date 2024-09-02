using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using POS_Test_1.DTOs;
using POS_Test_1.Interfaces;

namespace POS_Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ApiController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.RegisterUserAsync(registerDto);
            if (result)
                return Ok(new { Message = "Registration successful" });
            return BadRequest(new { Message = "Registration failed" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.LoginAsync(loginDto);
            if (result)
                return Ok(new { Message = "Login successful" });
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ForgotPasswordAsync(forgotPasswordDto);
            if (result)
                return Ok(new { Message = "Password reset email sent" });
            return BadRequest(new { Message = "Error sending reset email" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ResetPasswordAsync(resetPasswordDto);
            if (result)
                return Ok(new { Message = "Password reset successful" });
            return BadRequest(new { Message = "Invalid or expired reset token" });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ChangePasswordAsync(changePasswordDto);
            if (result)
                return Ok(new { Message = "Password changed successfully" });
            return BadRequest(new { Message = "Invalid email or old password" });
        }
    }
}
