using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleUserCore;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SLK.TryEdu.ModuleUser.Controllers; 

[Authorize]
[Route("api/User/[action]")]
[ApiController]
public class UserController : UserService, IUserService
{
    [Obsolete]
    public UserController(IMyContext ctx, ILogger<UserService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}