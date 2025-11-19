using System.ComponentModel.DataAnnotations;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MimeKit;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.WebHost.Services;
using static System.Net.WebRequestMethods;
namespace SLK.TryEdu.WebHost.Areas.Admin.Pages;

public class ForgotPassword : PageModel
{
    private readonly UserManager<SA_USER> _userManager;
    private readonly IMailSettingService _svcMailSettings;
    private readonly IOtpService _otpService;
    public ForgotPassword(UserManager<SA_USER> userMgr, IMailSettingService svcMailSettings, IOtpService svcotpService)
    {
        _userManager = userMgr;
        _svcMailSettings = svcMailSettings;
        _otpService = svcotpService;
    }
    [BindProperty]
    public string Value { get; set; }
    [BindProperty]
    [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
    public string UserId { get; set; }

    #region snippet
    public async Task<IActionResult> OnGet([FromRoute] string value)
    {
        await Task.CompletedTask;
        Value = value;
        return Page();
    }
    public async Task<IActionResult> OnPostSendOtpAsync([FromBody] SendOtpRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                return new JsonResult(new { success = false, message = "Tên đăng nhập không được để trống!" });
            }

            var user = await _userManager.FindByNameAsync(request.UserId);

            if (user == null)
            {
                return new JsonResult(new { success = false, message = "Tài khoản không tồn tại!" });
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                return new JsonResult(new { success = false, message = "Tài khoản không có email!" });
            }

            // Sinh mã OTP
            var otp = _otpService.GenerateOtp(user.UserName);

            // Gửi email chứa mã OTP
            string subject = $"Mã OTP đặt lại mật khẩu - Try Edu";

            string content = @"
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
                <table width='600' cellpadding='0' cellspacing='0' style='background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.07);'>
                    
                    <!-- Header với gradient -->
                    <tr>
                        <td style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 40px 30px; text-align: center;'>
                            <h1 style='margin: 0; color: #ffffff; font-size: 28px; font-weight: 700; letter-spacing: -0.5px;'>
                                📚 Try Edu
                            </h1>
                            <p style='margin: 10px 0 0 0; color: rgba(255, 255, 255, 0.9); font-size: 14px;'>
                                Nền tảng thi thử trực tuyến
                            </p>
                        </td>
                    </tr>
                    
                    <!-- Nội dung chính -->
                    <tr>
                        <td style='padding: 40px 30px;'>
                            <h2 style='margin: 0 0 20px 0; color: #1a202c; font-size: 22px; font-weight: 600;'>
                                Xin chào " + $"{user.LastName} {user.FirstName}" + @"! 👋
                            </h2>
                            
                            <p style='margin: 0 0 24px 0; color: #4a5568; font-size: 16px; line-height: 1.6;'>
                                Bạn vừa yêu cầu đặt lại mật khẩu tài khoản Try Edu. Sử dụng mã OTP bên dưới để tiếp tục:
                            </p>
                            
                            <!-- OTP Box -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='margin: 30px 0;'>
                                <tr>
                                    <td style='background: linear-gradient(135deg, #667eea15 0%, #764ba215 100%); border: 2px dashed #667eea; border-radius: 12px; padding: 30px; text-align: center;'>
                                        <p style='margin: 0 0 10px 0; color: #718096; font-size: 14px; font-weight: 500; text-transform: uppercase; letter-spacing: 1px;'>
                                            Mã OTP của bạn
                                        </p>
                                        <p style='margin: 0; color: #667eea; font-size: 42px; font-weight: 700; letter-spacing: 8px; font-family: ""Courier New"", monospace;'>
                                            " + $"{otp}" + @"
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            
                            <!-- Cảnh báo -->
                            <table width='100%' cellpadding='0' cellspacing='0' style='background-color: #fff5f5; border-left: 4px solid #fc8181; border-radius: 8px; margin: 24px 0;'>
                                <tr>
                                    <td style='padding: 16px 20px;'>
                                        <p style='margin: 0; color: #c53030; font-size: 14px; line-height: 1.5;'>
                                            ⏰ <strong>Lưu ý:</strong> Mã OTP này có hiệu lực trong <strong>1 phút</strong>. Vui lòng không chia sẻ mã này với bất kỳ ai.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            
                            <p style='margin: 24px 0 0 0; color: #718096; font-size: 14px; line-height: 1.6;'>
                                Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email hoặc liên hệ với chúng tôi ngay lập tức.
                            </p>
                        </td>
                    </tr>
                    
                    <!-- Footer -->
                    <tr>
                        <td style='background-color: #f7fafc; padding: 30px; text-align: center; border-top: 1px solid #e2e8f0;'>
                            <p style='margin: 0 0 10px 0; color: #4a5568; font-size: 14px;'>
                                <strong>Try Edu</strong> - Học tập thông minh, Tương lai rộng mở
                            </p>
                            <p style='margin: 0 0 15px 0; color: #a0aec0; font-size: 12px;'>
                                Email này được gửi tự động, vui lòng không trả lời.
                            </p>
                            <p style='margin: 0; color: #cbd5e0; font-size: 11px;'>
                                © 2025 Try Edu. All rights reserved.
                            </p>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

            MailRequest mail = new MailRequest()
            {
                Subject = subject,
                ToEmail = user.Email,
                Content = content,
                Attachments = new()
            };
            _ = Task.Run(async () => {
                try
                {
                    await _svcMailSettings.SendMail(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            });
            return new JsonResult(new
            {
                success = true,
                message = $"Mã OTP đã được gửi đến email {_otpService.MaskEmail(user.Email)}",
                email = _otpService.MaskEmail(user.Email)
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new { success = false, message = "Đã có lỗi xảy ra khi gửi OTP!" });
        }
    }
    //Ẩn mail
  
    #endregion
}
public class SendOtpRequest
{
    public string UserId { get; set; }
}