using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using SLK.TryEdu.WebHost.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SLK.TryEdu.WebHost.Controllers;

/// <summary>
/// API Controller cho Student Authentication (EntityUser)
/// Chỉ xử lý authentication cho Student, không xử lý Admin/Partner
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
[AllowAnonymous]
public class StudentAuthController : ControllerBase
{
    private readonly IMyContext _ctx;
    private readonly IConfiguration _config;
    private readonly ILogger<StudentAuthController> _logger;

    public StudentAuthController(
        IMyContext ctx,
        IConfiguration config,
        ILogger<StudentAuthController> logger)
    {
        _ctx = ctx;
        _config = config;
        _logger = logger;
    }

    /// <summary>
    /// Đăng nhập học viên (EntityUser)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new UserLoginResponse
                {
                    Success = false,
                    Message = "Dữ liệu không hợp lệ"
                });
            }

            using (var db = _ctx.ConnectDb())
            {
                var user = await db.Repo<EntityUser>()
                    .Query(u => u.Email == request.Email.ToLower().Trim() && u.IsActive)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return Unauthorized(new UserLoginResponse
                    {
                        Success = false,
                        Message = "Email hoặc mật khẩu không đúng"
                    });
                }

                // Verify password
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return Unauthorized(new UserLoginResponse
                    {
                        Success = false,
                        Message = "Email hoặc mật khẩu không đúng"
                    });
                }

                // Update last login
                user.LastLogin = DateTime.UtcNow;
                await db.Repo<EntityUser>().Update(user);

                // Generate JWT token
                var token = GenerateJwtToken(user);

                var response = new UserLoginResponse
                {
                    Success = true,
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddDays(7), // Token expires in 7 days
                    User = new UserInfo
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FullName = user.FullName,
                        IsVerified = user.IsVerified,
                        Phone = user.Phone,
                        Country = user.Country,
                        City = user.City
                    },
                    Message = "Đăng nhập thành công"
                };

                return Ok(response);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login error for email: {Email}", request.Email);
            return StatusCode(500, new UserLoginResponse
            {
                Success = false,
                Message = "Đã có lỗi xảy ra khi đăng nhập"
            });
        }
    }

    /// <summary>
    /// Đăng ký học viên mới (EntityUser)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Result<UserInfo>.Failure("Dữ liệu không hợp lệ", 
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }

            if (!request.AgreeToTerms)
            {
                return BadRequest(Result<UserInfo>.Failure("Vui lòng đồng ý với điều khoản sử dụng"));
            }

            using (var db = _ctx.ConnectDb())
            {
                // Check if email already exists
                var existingUser = await db.Repo<EntityUser>()
                    .Query(u => u.Email == request.Email.ToLower().Trim())
                    .FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    return Conflict(Result<UserInfo>.Failure("Email đã được sử dụng"));
                }

                // Validate password strength
                if (!IsPasswordStrong(request.Password))
                {
                    return BadRequest(Result<UserInfo>.Failure(
                        "Mật khẩu phải có ít nhất 6 ký tự, bao gồm chữ hoa, chữ thường và số"));
                }

                // Create new user
                var user = new EntityUser
                {
                    Email = request.Email.ToLower().Trim(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    Phone = request.Phone?.Trim(),
                    Country = request.Country?.Trim(),
                    City = request.City?.Trim(),
                    IsActive = true,
                    IsVerified = false,
                    DateCreated = DateTime.UtcNow
                };

                await db.Repo<EntityUser>().Insert(user);

                // Generate JWT token
                var token = GenerateJwtToken(user);

                var userInfo = new UserInfo
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    IsVerified = user.IsVerified,
                    Phone = user.Phone,
                    Country = user.Country,
                    City = user.City
                };

                return Ok(new
                {
                    Success = true,
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddDays(7),
                    User = userInfo,
                    Message = "Đăng ký thành công"
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Register error for email: {Email}", request.Email);
            return StatusCode(500, Result<UserInfo>.Failure("Đã có lỗi xảy ra khi đăng ký"));
        }
    }

    /// <summary>
    /// Validate JWT token và trả về thông tin user
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ValidateToken([FromBody] string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtToken:SigningKey") ?? "YourSecretKeyForJWTTokenSigning");

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _config.GetValue<string>("JwtToken:Issuer"),
                ValidateAudience = true,
                ValidAudience = _config.GetValue<string>("JwtToken:Audience"),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);

            using (var db = _ctx.ConnectDb())
            {
                var user = await db.Repo<EntityUser>()
                    .Query(u => u.Id == userId && u.IsActive)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return Unauthorized(new { Success = false, Message = "Người dùng không tồn tại hoặc đã bị khóa" });
                }

                var userInfo = new UserInfo
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    IsVerified = user.IsVerified,
                    Phone = user.Phone,
                    Country = user.Country,
                    City = user.City
                };

                return Ok(new { Success = true, User = userInfo });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token validation error");
            return Unauthorized(new { Success = false, Message = "Token không hợp lệ" });
        }
    }

    /// <summary>
    /// Generate JWT token for EntityUser
    /// </summary>
    private string GenerateJwtToken(EntityUser user)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtToken:SigningKey") ?? "YourSecretKeyForJWTTokenSigning"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("firstName", user.FirstName ?? ""),
            new Claim("lastName", user.LastName ?? ""),
            new Claim("fullName", user.FullName ?? ""),
            new Claim("userType", "Student"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _config.GetValue<string>("JwtToken:Issuer") ?? "TryEdu",
            audience: _config.GetValue<string>("JwtToken:Audience") ?? "TryEdu",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Validate password strength
    /// </summary>
    private bool IsPasswordStrong(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            return false;

        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);

        return hasUpper && hasLower && hasDigit;
    }
}

