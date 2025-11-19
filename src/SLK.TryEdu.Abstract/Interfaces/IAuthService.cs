using System;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

public interface IAuthService
{
    Task<RspLogin> Login(LoginRequest request);

    Task<Tuple<bool, string>> Logout();

    Task<InfoUser> ValidateTokenInCookie();
}