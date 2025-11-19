using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SLK.TryEdu.Base;
using System.Data;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SLK.TryEdu.ModuleUserCore;

namespace SLK.TryEdu.ModuleUser;

public class UserService : MyServiceBase, IUserService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<UserService> _log;
    private readonly string _ternantId;

    public UserService(IMyContext ctx, ILogger<UserService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
    public async Task<ResultOf<EntityUser>> Get(Guid guid)
    {
        if (!_ctx.CheckPermission(PERMISSION.USER_VIEW))
            return ResultOf<EntityUser>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            var data = await _ctx.Repo<EntityUser>().Query(t => t.Guid == guid)
                .SingleOrDefaultAsync();

            return ResultOf<EntityUser>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return ResultOf<EntityUser>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<EntityUser>> GetList()
    {
        if (!_ctx.CheckPermission(PERMISSION.USER_VIEW))
            return ResultsOf<EntityUser>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            var data = await _ctx.Repo<EntityUser>().GetList();

            return ResultsOf<EntityUser>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<EntityUser>.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> Save([Body] EntityUser info)
    {
        if (!_ctx.CheckPermission(PERMISSION.USER_CREATE_UPDATE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            if (info.Id > 0)
            {
                await _ctx.Repo<EntityUser>().Update(info);

                var user = await _ctx.Set<SA_USER>().FirstOrDefaultAsync(x => x.GuidEmployee == info.Guid);
                if (user != null)
                {
                    user.LastName = info.LastName;
                    user.FirstName = info.FirstName;
                    user.Email = info.Email;
                    user.PhoneNumber = info.Phone;

                    _ctx.Set<SA_USER>().Update(user);
                }
            }
            else
            {
                if (info.Guid == Guid.Empty)
                {
                    await _ctx.Repo<EntityUser>().Insert(info);
                }
            }

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, _ctx.Summary);
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

}