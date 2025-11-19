using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.WebHost.Models;
using SLK.TryEdu.WebHost.Services;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class VerifyEmailModel : PageModel
    {
        private readonly IRepository<EntityUser> _userRepository;
        private readonly IOtpService _otpService;
        private readonly IMailSettingService _mailService;

        public VerifyEmailModel(
            IRepository<EntityUser> userRepository,
            IOtpService otpService,
            IMailSettingService mailService)
        {
            _userRepository = userRepository;
            _otpService = otpService;
            _mailService = mailService;
        }

        public IActionResult OnGet()
        {
            if (TempData["UserEmail"] == null)
            {
                return Redirect("/student/register");
            }
            return Page();
        }

        [BindProperty]
        public OtpVerificationRequest OtpRequest { get; set; }

        public int OtpTimeLeft { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var email = TempData["UserEmail"]?.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    TempData["ErrorMessage"] = "Email không hợp lệ";
                    return RedirectToPage("/Register");
                }

                // Verify OTP
                if (!_otpService.VerifyOtp(email, OtpRequest.Otp))
                {
                    ModelState.AddModelError("error", "Mã OTP không đúng hoặc đã hết hạn");
                    TempData["UserEmail"] = email;
                    return Page();
                }

                // Update user as verified
                var user = await _userRepository.GetOne(u => u.Email == email);
                if (user != null)
                {
                    user.IsVerified = true;
                    user.EmailVerifiedAt = DateTime.UtcNow;
                    await _userRepository.Update(user);
                }

                // Remove OTP
                _otpService.RemoveOtp(email);

                TempData["SuccessMessage"] = "Xác thực email thành công! Bạn có thể đăng nhập ngay.";
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", $"Lỗi xác thực: {ex.Message}");
                return Page();
            }
        }

        // ✅ METHOD LẤY THỜI GIAN CÒN LẠI
        public async Task<IActionResult> OnGetOtpTimeLeftAsync()
        {
            try
            {
                var email = TempData["UserEmail"]?.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    return new JsonResult(new { success = false, timeLeft = 0, expired = true });
                }

                var expiryTime = _otpService.GetOtpExpiryTime(email);
                if (expiryTime == null)
                {
                    return new JsonResult(new { success = false, timeLeft = 0, expired = true });
                }

                var timeLeft = (int)(expiryTime.Value - DateTime.UtcNow).TotalSeconds;
                if (timeLeft <= 0)
                {
                    return new JsonResult(new { success = false, timeLeft = 0, expired = true });
                }

                return new JsonResult(new { success = true, timeLeft = timeLeft, expired = false });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, timeLeft = 0, expired = true });
            }
        }
        public async Task<IActionResult> OnPostVerifyOtpAsync()
        {
            try
            {
                var email = TempData["UserEmail"]?.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    return new JsonResult(new { success = false, message = "Email không hợp lệ" });
                }

                if (!_otpService.VerifyOtp(email, OtpRequest.Otp))
                {
                    return new JsonResult(new { success = false, message = "Mã OTP không đúng hoặc đã hết hạn" });
                }

                // Update user as verified
                var user = await _userRepository.GetOne(u => u.Email == email);
                if (user != null)
                {
                    user.IsVerified = true;
                    user.EmailVerifiedAt = DateTime.UtcNow;
                    await _userRepository.Update(user);
                }

                _otpService.RemoveOtp(email);
                return new JsonResult(new { success = true, message = "Xác thực thành công!" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }
        public async Task<IActionResult> OnPostResendOtpAsync()
        {
            try
            {
                var email = TempData["UserEmail"]?.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    return new JsonResult(new { success = false, message = "Email không hợp lệ" });
                }

                var user = await _userRepository.GetOne(u => u.Email == email);
                if (user == null)
                {
                    return new JsonResult(new { success = false, message = "Email không tồn tại" });
                }

                var otp = _otpService.GenerateOtp(user.Email);
                await SendVerificationEmail(user, otp);

                return new JsonResult(new { success = true, message = "Mã OTP mới đã được gửi!" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }
        private async Task SendVerificationEmail(EntityUser user, string otp)
        {
            string subject = $"Xác thực tài khoản TryEdu - Mã OTP";

            string content = $@"
<!DOCTYPE html>
<html lang='vi'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
</head>
<body style='margin: 0; padding: 0; background-color: #f5f7fa; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, ""Helvetica Neue"", Arial, sans-serif;'>
    <table width='100%' cellpadding='0' cellspacing='0' style='background-color: #f5f7fa; padding: 40px 20px;'>
        <tr>
            <td align='center'>
                <table width='600' cellpadding='0' cellspacing='0' style='background-color: #ffffff; border-radius: 16px; box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1); overflow: hidden;'>
                    
                    <!-- Header -->
                    <tr>
                        <td style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 40px 30px; text-align: center;'>
                            <h1 style='margin: 0; color: #ffffff; font-size: 28px; font-weight: 700;'>
                                🔄 Mã OTP mới
                            </h1>
                        </td>
                    </tr>
                    
                    <!-- Nội dung chính -->
                    <tr>
                        <td style='padding: 40px 30px;'>
                            <h2 style='margin: 0 0 20px 0; color: #1a202c; font-size: 22px; font-weight: 600;'>
                                Xin chào {user.LastName} {user.FirstName}! 👋
                            </h2>
                            
                            <p style='margin: 0 0 24px 0; color: #4a5568; font-size: 16px; line-height: 1.6;'>
                                Đây là mã OTP mới để xác thực tài khoản TryEdu của bạn:
                            </p>
                            
                            <!-- OTP Box -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='margin: 30px 0;'>
                                <tr>
                                    <td style='background: linear-gradient(135deg, #667eea15 0%, #764ba215 100%); border: 2px dashed #667eea; border-radius: 12px; padding: 30px; text-align: center;'>
                                        <p style='margin: 0 0 10px 0; color: #718096; font-size: 14px; font-weight: 500; text-transform: uppercase; letter-spacing: 1px;'>
                                            Mã xác thực mới
                                        </p>
                                        <p style='margin: 0; color: #667eea; font-size: 42px; font-weight: 700; letter-spacing: 8px; font-family: ""Courier New"", monospace;'>
                                            {otp}
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            
                            <!-- Cảnh báo -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='background-color: #fff5f5; border-left: 4px solid #fc8181; border-radius: 8px; margin: 24px 0;'>
                                <tr>
                                    <td style='padding: 20px;'>
                                        <p style='margin: 0 0 10px 0; color: #c53030; font-size: 14px; font-weight: 600;'>
                                            ⚠️ Lưu ý quan trọng:
                                        </p>
                                        <ul style='margin: 0; padding-left: 20px; color: #c53030; font-size: 14px; line-height: 1.6;'>
                                            <li>Mã OTP này có hiệu lực trong 1 phút</li>
                                            <li>Mã OTP cũ sẽ không còn hiệu lực</li>
                                            <li>Không chia sẻ mã này với bất kỳ ai</li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <!-- Footer -->
                    <tr>
                        <td style='background-color: #f7fafc; padding: 30px; text-align: center; border-top: 1px solid #e2e8f0;'>
                            <p style='margin: 0 0 10px 0; color: #4a5568; font-size: 14px;'>
                                <strong>TryEdu</strong> - Học tập thông minh, Tương lai rộng mở
                            </p>
                            <p style='margin: 0; color: #cbd5e0; font-size: 11px;'>
                                © 2025 TryEdu. All rights reserved.
                            </p>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

            var mailRequest = new MailRequest()
            {
                Subject = subject,
                ToEmail = user.Email,
                Content = content,
                Attachments = new()
            };

            // Gửi email bất đồng bộ
            _ = Task.Run(async () =>
            {
                try
                {
                    await _mailService.SendMail(mailRequest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending verification email: {ex.Message}");
                }
            });

            await Task.CompletedTask;
        }
        public class OtpVerificationRequest
        {
            [Required(ErrorMessage = "Mã OTP là bắt buộc")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã OTP phải có 6 số")]
            public string Otp { get; set; }
        }

        public class ResendOtpRequest
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }
    }
}