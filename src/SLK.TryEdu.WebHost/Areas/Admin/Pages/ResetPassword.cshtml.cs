using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using SLK.TryEdu.WebHost.Services;

namespace SLK.TryEdu.WebHost.Areas.Admin.Pages;

public class ResetPassword : PageModel
{
    private readonly UserManager<SA_USER> _userManager;
    private readonly IOtpService _otpService;

    public ResetPassword(UserManager<SA_USER> userMgr, IOtpService svcotpService)
    {
        _userManager = userMgr;
        _otpService = svcotpService;
    }

    public string UserId { get; set; }
    public bool IsCheckUserId { get; set; } = true;
    public string Token { get; set; }

    [BindProperty]
    public string Value { get; set; }

    [BindProperty]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Mật khẩu 8-15 ký tự, gồm hoa, thường, số, đặc biệt.")]
    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    public string Password { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không khớp!")]
    public string PasswordConfirm { get; set; }

    #region snippet
    public async Task<IActionResult> OnGet([FromRoute] string value)
    {
        await Task.CompletedTask;
        UserId = Request.Query["userid"].ToString();
      if (!_otpService.CheckOtpExists(UserId))
        {
            IsCheckUserId = false;
        }
        Value = value;
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        UserId = Request.Query["userid"].ToString();
        Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(Request.Query["token"].ToString()));

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.FindByNameAsync(UserId);

        if (user == null)
        {
            ModelState.AddModelError("PasswordConfirm", "Tài khoản không tồn tại!");
            return Page();
        }

        var reset = await _userManager.ResetPasswordAsync(user, Token, Password);
        if (!reset.Succeeded)
        {
            ModelState.AddModelError("PasswordConfirm", "Đã có lỗi xảy ra!");
            return Page();
        }

        return Redirect("/reset-password/success");
    }
    public async Task<IActionResult> OnPostVerifyOtpAsync([FromBody] VerifyOtpRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.UserId))
                return new JsonResult(new { success = false, message = "Tên đăng nhập không hợp lệ!" });

            if (string.IsNullOrEmpty(request.Otp))
                return new JsonResult(new { success = false, message = "Vui lòng nhập mã OTP!" });

            var user = await _userManager.FindByNameAsync(request.UserId);
            if (user == null)
                return new JsonResult(new { success = false, message = "Tài khoản không tồn tại!" });

            if (!_otpService.VerifyOtp(request.UserId, request.Otp))
                return new JsonResult(new { success = false, message = "Mã OTP không đúng hoặc đã hết hạn!" });

            return new JsonResult(new { success = true, message = "Xác thực OTP thành công!" });
        }
        catch (Exception ex)
        {
            return new JsonResult(new { success = false, message = "Đã có lỗi xảy ra!" });
        }
    }

    // ✅ Handler: Reset Password với OTP đã verify (Bước 2)
    public async Task<IActionResult> OnPostResetPasswordWithOtpAsync([FromBody] ResetPasswordRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.UserId))
                return new JsonResult(new { success = false, message = "Tên đăng nhập không hợp lệ!" });

            if (string.IsNullOrEmpty(request.Otp))
                return new JsonResult(new { success = false, message = "Vui lòng nhập mã OTP!" });

            if (string.IsNullOrEmpty(request.Password))
                return new JsonResult(new { success = false, message = "Vui lòng nhập mật khẩu mới!" });

            if (request.Password != request.PasswordConfirm)
                return new JsonResult(new { success = false, message = "Xác nhận mật khẩu không khớp!" });

            var passwordRegex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            if (!passwordRegex.IsMatch(request.Password))
                return new JsonResult(new { success = false, message = "Mật khẩu 8-15 ký tự, gồm hoa, thường, số, đặc biệt." });

            var user = await _userManager.FindByNameAsync(request.UserId);
            if (user == null)
                return new JsonResult(new { success = false, message = "Tài khoản không tồn tại!" });

            if (!_otpService.VerifyOtp(request.UserId, request.Otp))
                return new JsonResult(new { success = false, message = "Mã OTP không đúng hoặc đã hết hạn!" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.Password);

            if (!result.Succeeded)
                return new JsonResult(new { success = false, message = "Không thể đặt lại mật khẩu. Vui lòng thử lại!" });

            _otpService.RemoveOtp(request.UserId);

            return new JsonResult(new { success = true, message = "Đặt lại mật khẩu thành công!" });
        }
        catch (Exception ex)
        {
            return new JsonResult(new { success = false, message = "Đã có lỗi xảy ra!" });
        }
    }
    #endregion
}
public class VerifyOtpRequest
{
    public string UserId { get; set; }
    public string Otp { get; set; }
}
public class ResetPasswordRequest
{
    public string UserId { get; set; }
    public string Otp { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}