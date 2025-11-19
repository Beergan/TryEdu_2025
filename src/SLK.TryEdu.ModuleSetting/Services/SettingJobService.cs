using Hangfire.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static MudBlazor.CategoryTypes;

namespace SLK.TryEdu.ModuleSetting;

public class SettingJobService : MyServiceBase, ISettingJobService
{
    private readonly ILogger<SettingJobService> _log;
    private readonly IServiceProvider _svcProvider;

    public SettingJobService(IMyContext ctx, ILogger<SettingJobService> logger, IServiceProvider svcProvider) : base(ctx)
    {
        _log = logger;
        _svcProvider = svcProvider;
    }

    public async Task<ResultOf<EntityJob>> Get(Guid guid)
    {     
        try
        {
            var data = await _ctx.Repo<EntityJob>().GetOne(x => x.Guid == guid);
            return ResultOf<EntityJob>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return ResultOf<EntityJob>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<EntityJob>> GetList()
    {
        if (!_ctx.CheckPermission(PERMISSION.JOB_VIEW))
            return ResultsOf<EntityJob>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            var data = await _ctx.Repo<EntityJob>().Query().ToListAsync();
            return ResultsOf<EntityJob>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<EntityJob>.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> Save([Body] EntityJob info)
    {
        if (!_ctx.CheckPermission(PERMISSION.JOB_EDIT_SAVE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            if (info.Id > 0)
            {
                EntityJob old = await _ctx.Repo<EntityJob>().Query().FirstAsync(x => x.Id == info.Id);

                await _ctx.Repo<EntityJob>().Update(info);
            }
            else
            {
                await _ctx.Repo<EntityJob>().Insert(info);
            }
            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, _ctx.Summary);
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> Delete(int id)
    {
        if (!_ctx.CheckPermission(PERMISSION.JOB_DELETE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            var item = await _ctx.Set<EntityJob>().FindAsync(id);

            await _ctx.Repo<EntityJob>().Remove(item);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
}