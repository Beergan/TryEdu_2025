using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLK.TryEdu.Abstract;
namespace SLK.TryEdu.WebHost.Areas.Admin.Pages;

public class LoginModel : PageModel
{
    private readonly UserManager<SA_USER> _userManager;
    private readonly IAuthService _authSvc;

    public ITextTranslator Text { get; set; }
    public LoginModel(IAuthService svc, ITextTranslator text, UserManager<SA_USER> userManager  )
    {
        _authSvc = svc;
        Text = text;
        _userManager = userManager;
    }

    public IActionResult OnGet()
    {

        if (User.Identity.IsAuthenticated && User.Identity.AuthenticationType == "AdminCookies")
        {
            return Redirect("/admin");
        }
        return Page();
    }

    [BindProperty]
    [Required]
    public string UserId { get; set; }

    [BindProperty]
    [Required]
    public string Password { get; set; }

    #region snippet
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("error", "Bạn chưa nhập tài khoản hoặc mật khẩu!");
            return Page();
        }


        var user = await _userManager.FindByNameAsync(UserId);

        if (user == null)
        {
            ModelState.AddModelError("error", "Tài khoản hoặc mật khẩu không chính xác!");
            return Page();
        }

        if (user.Active == true)
        {
            var rsp = await _authSvc.Login(new LoginRequest { UserName = UserId, Password = Password });

            if (!rsp.Success || user.UserName != UserId)
            {
                ModelState.AddModelError("error", "Tài khoản hoặc mật khẩu không chính xác!");
                return Page();
            }
        }
        else
        {
            ModelState.AddModelError("error", "Tài khoản của bạn chưa được kích hoạt!");
            return Page();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, UserId),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim("UserId", user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "AdminCookies");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
        };

        await HttpContext.SignInAsync("AdminCookies", new ClaimsPrincipal(claimsIdentity), authProperties);
        HttpContext.Response.Cookies.Delete("blazorMode");
        HttpContext.Response.Cookies.Append("blazorMode", "server", new CookieOptions { Expires = DateTime.Now.AddDays(30) });
        return Redirect("~/admin");
    }

    #endregion
}