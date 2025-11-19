using System;
using System.Security;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;


namespace SLK.TryEdu.ModuleSetting;

public class SettingCompanyService : MyServiceBase, ISettingCompanyService
{
    private readonly ILogger<SettingCompanyService> _log;

    public SettingCompanyService(IMyContext ctx, ILogger<SettingCompanyService> logger) : base(ctx)
    {
        _log = logger;
    }
    public async Task<ResultOf<EntityCompany>> Get()
    {
        using (var db = _ctx.ConnectDb())
        {
            try
            {
                var item = await db.Set<EntityCompany>().FirstOrDefaultAsync();

                return ResultOf<EntityCompany>.Ok(item);
            }
            catch (Exception ex)
            {
                _log.LogError($"{_ctx.Summary} - {ex.Message}");
                return ResultOf<EntityCompany>.Error("Đã có lỗi xảy ra!");
            }
        }
    }
    public async Task<Result> Save([Body] EntityCompany info)
    {
        using (var db = _ctx.ConnectDb())
        {
            try
            {
                if (info.Id > 0)
                {
                    await db.Repo<EntityCompany>().Update(info);
                }
                else
                {
                    await db.Repo<EntityCompany>().Insert(info);
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
    public bool CheckPermission()
    {
        return !_ctx.CheckPermission(PERMISSION.COMPANY_EDIT_SAVE);
    }
}