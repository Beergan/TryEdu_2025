using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLK.TryEdu.WebHost.Models;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.Abstract;
using Org.BouncyCastle.Crypto.Generators;
using SLK.TryEdu.WebHost.Services;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class RegisterModel : PageModel 
    {
        private readonly IRepository<EntityUser> _userRepository;
        private readonly ITextTranslator _textTranslator;
        private readonly IOtpService _otpService ;
        private readonly IMailSettingService _svcMailSettings;

        public RegisterModel(IRepository<EntityUser> userRepository, ITextTranslator textTranslator, IOtpService otpService, IMailSettingService svcMailSettings)
        {
            _userRepository = userRepository;
            _textTranslator = textTranslator;
            _otpService = otpService;
            _svcMailSettings = svcMailSettings;
        }

        public IActionResult OnGet()
        {
            if (Request.Cookies.ContainsKey("UserAuth"))
            {
                return Redirect("/dashboard");
            }
            return Page();

        }
        [BindProperty]
        public UserRegisterRequest RegisterRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            bool isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!RegisterRequest.AgreeToTerms)
            {
                if (isAjax)
                    return new JsonResult(new { success = false, message = "Vui lòng đồng ý với điều khoản sử dụng" });
                ModelState.AddModelError("error", "Vui lòng đồng ý với điều khoản sử dụng");
                return Page();
            }

            try
            {
                var email = RegisterRequest.Email;

                var existingUser = await _userRepository.GetOne(u => u.Email == RegisterRequest.Email);
                if (existingUser != null)
                {
                    if (existingUser.IsVerified == false)
                    {
                        existingUser.Email = RegisterRequest.Email.ToLower().Trim();
                        existingUser.PasswordHash = Convert.ToBase64String(BCrypt.PasswordToByteArray(RegisterRequest.Password.ToCharArray()));
                        existingUser.FirstName = RegisterRequest.FirstName.Trim();
                        existingUser.LastName = RegisterRequest.LastName.Trim();
                        existingUser.Phone = RegisterRequest.Phone?.Trim();
                        existingUser.Country = RegisterRequest.Country?.Trim();
                        existingUser.City = RegisterRequest.City?.Trim();
                        existingUser.IsVerified = false;
                        await _userRepository.Update(existingUser);
                        var otpexistingUser = _otpService.GenerateOtp(existingUser.Email);
                        await SendVerificationEmail(existingUser, otpexistingUser);
                        TempData["SuccessMessage"] = $"Đăng ký thành công! Mã xác thực đã được gửi đến email {_otpService.MaskEmail(existingUser.Email)}";
                        TempData["UserEmail"] = existingUser.Email;
                        TempData.Keep("UserEmail");
                        if (isAjax)
                        {
                            return new JsonResult(new
                            {
                                success = true,
                                message = $"Đăng ký thành công! Mã OTP đã được gửi đến {_otpService.MaskEmail(existingUser.Email)}"
                            });
                        }
                        return RedirectToPage("/verifyemail");
                    }
                    else
                    {
                        if (isAjax)
                            return new JsonResult(new { success = false, message = "Email đã được sử dụng" });
                        return Page();

                    }
                }

                if (!IsPasswordStrong(RegisterRequest.Password))
                {
                    ModelState.AddModelError("error", "Mật khẩu phải có ít nhất 6 ký tự, bao gồm chữ hoa, chữ thường và số");
                    return Page();
                }

                var user = new EntityUser
                {
                    Email = RegisterRequest.Email.ToLower().Trim(),
                    PasswordHash = Convert.ToBase64String(BCrypt.PasswordToByteArray(RegisterRequest.Password.ToCharArray())),
                    FirstName = RegisterRequest.FirstName.Trim(),
                    LastName = RegisterRequest.LastName.Trim(),
                    Phone = RegisterRequest.Phone?.Trim(),
                    Country = RegisterRequest.Country?.Trim(),
                    City = RegisterRequest.City?.Trim(),
                    IsActive = true,
                    IsVerified = false,
                };

                await _userRepository.Insert(user);
                var otp = _otpService.GenerateOtp(user.Email);
                await SendVerificationEmail(user, otp);
      
                TempData["SuccessMessage"] = $"Đăng ký thành công! Mã xác thực đã được gửi đến email {_otpService.MaskEmail(user.Email)}";
                TempData["UserEmail"] = user.Email;
                TempData.Keep("UserEmail");
                if (isAjax)
                {
                    return new JsonResult(new
                    {
                        success = true,
                        message = $"Đăng ký thành công! Mã OTP đã được gửi đến {_otpService.MaskEmail(user.Email)}"
                    });
                }
                return RedirectToPage("/verifyemail");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", $"Lỗi đăng ký: {ex.Message}");
                return Page();
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
                                🎉 Chào mừng đến với TryEdu!
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
                                Cảm ơn bạn đã đăng ký tài khoản TryEdu! Để hoàn tất quá trình đăng ký, vui lòng sử dụng mã OTP bên dưới để xác thực email:
                            </p>
                            
                            <!-- OTP Box -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='margin: 30px 0;'>
                                <tr>
                                    <td style='background: linear-gradient(135deg, #667eea15 0%, #764ba215 100%); border: 2px dashed #667eea; border-radius: 12px; padding: 30px; text-align: center;'>
                                        <p style='margin: 0 0 10px 0; color: #718096; font-size: 14px; font-weight: 500; text-transform: uppercase; letter-spacing: 1px;'>
                                            Mã xác thực của bạn
                                        </p>
                                        <p style='margin: 0; color: #667eea; font-size: 42px; font-weight: 700; letter-spacing: 8px; font-family: ""Courier New"", monospace;'>
                                            {otp}
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            
                            <!-- Hướng dẫn -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='background-color: #f0f9ff; border-left: 4px solid #3b82f6; border-radius: 8px; margin: 24px 0;'>
                                <tr>
                                    <td style='padding: 20px;'>
                                        <p style='margin: 0 0 10px 0; color: #1e40af; font-size: 14px; font-weight: 600;'>
                                            📋 Hướng dẫn xác thực:
                                        </p>
                                        <ul style='margin: 0; padding-left: 20px; color: #1e40af; font-size: 14px; line-height: 1.6;'>
                                            <li>Nhập mã OTP trên vào trang xác thực</li>
                                            <li>Mã OTP có hiệu lực trong 5 phút</li>
                                            <li>Nếu không nhận được email, kiểm tra thư mục Spam</li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                            
                            <p style='margin: 24px 0 0 0; color: #4a5568; font-size: 16px; line-height: 1.6;'>
                                Sau khi xác thực thành công, bạn có thể đăng nhập và bắt đầu học tập ngay!
                            </p>
                        </td>
                    </tr>
                    
                    <!-- Footer -->
                    <tr>
                        <td style='background-color: #f7fafc; padding: 30px; text-align: center; border-top: 1px solid #e2e8f0;'>
                            <p style='margin: 0 0 10px 0; color: #4a5568; font-size: 14px;'>
                                <strong>TryEdu</strong> - Học tập thông minh, Tương lai rộng mở
                            </p>
                            <p style='margin: 0 0 15px 0; color: #a0aec0; font-size: 12px;'>
                                Email này được gửi tự động, vui lòng không trả lời.
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

            _ = Task.Run(async () => {
                try
                {
                    await _svcMailSettings.SendMail(mailRequest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending verification email: {ex.Message}");
                }
            });
            await Task.CompletedTask;
        }
        private bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpper && hasLower && hasDigit;
        }

        public async Task<IActionResult> OnGetCheckEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new JsonResult(new { exists = false, message = "" });
            }

            try
            {
                var user = await _userRepository.GetOne(u => u.Email == email.ToLower().Trim());
                if (user != null)
                {
                    return new JsonResult(new { exists = true, message = "Email đã được sử dụng" });
                }
                else
                {
                    return new JsonResult(new { exists = false, message = "Email có thể sử dụng" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { exists = false, message = $"Lỗi kiểm tra: {ex.Message}" });
            }
        }
    }
}
