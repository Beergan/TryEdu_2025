using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLK.TryEdu.WebHost.Models;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.Abstract;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNetCore.Authentication;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRepository<EntityUser> _userRepository;
        private readonly ITextTranslator _textTranslator;

        public LoginModel(IRepository<EntityUser> userRepository, ITextTranslator textTranslator)
        {
            _userRepository = userRepository;
            _textTranslator = textTranslator;
        }

        public IActionResult OnGet()
        {
           
            return Page();
        }

        [BindProperty]
        public UserLoginRequest LoginRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Find user by email
                var user = await _userRepository.GetOne(u => u.Email == LoginRequest.Email);
                
                if (user == null)
                {
                    ModelState.AddModelError("error", "Email không tồn tại trong hệ thống");
                    return Page();
                }
                
                if (!user.IsActive)
                {
                    ModelState.AddModelError("error", "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên");
                    return Page();
                }
                
            
                //if (!BCrypt.Generate(LoginRequest.Password, user.PasswordHash))
                //{
                //    ModelState.AddModelError("error", "Mật khẩu không chính xác");
                //    return Page();
                //}
                
                // Update last login
                user.LastLogin = DateTime.UtcNow;
                await _userRepository.Update(user);
                
                // Set authentication cookies
                var claims = new List<System.Security.Claims.Claim>
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Email),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
                    new System.Security.Claims.Claim("UserId", user.Id.ToString()),
                    new System.Security.Claims.Claim("FullName", user.FullName),
                    new System.Security.Claims.Claim("IsVerified", user.IsVerified.ToString())
                };

                var claimsIdentity = new System.Security.Claims.ClaimsIdentity(claims, "UserCookies");
                var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                {
                    IsPersistent = LoginRequest.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(LoginRequest.RememberMe ? 30 : 1)
                };

                await HttpContext.SignInAsync("UserCookies", new System.Security.Claims.ClaimsPrincipal(claimsIdentity), authProperties);

                return Redirect("/student/dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", $"Lỗi đăng nhập: {ex.Message}");
                return Page();
            }
        }
    }
}
