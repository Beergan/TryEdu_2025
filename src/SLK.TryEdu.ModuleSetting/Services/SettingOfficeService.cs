using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestEase;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;

namespace SLK.TryEdu.ModuleSetting;

public class SettingOfficeService : MyServiceBase, ISettingOfficeService
{
    private readonly ILogger<SettingOfficeService> _log;

    public SettingOfficeService(IMyContext ctx, ILogger<SettingOfficeService> logger) : base(ctx)
    {
        _log = logger;
    }

    public async Task<ResultOf<EntityOffice>> Get()
    {
        try
        {
            var data = await _ctx.Repo<EntityOffice>().GetOne();
            return ResultOf<EntityOffice>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return ResultOf<EntityOffice>.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<ResultsOf<EntityOffice>> GetList()
    {
        if (!_ctx.CheckPermission(PERMISSION.OFFICE_VIEW))
            return ResultsOf<EntityOffice>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            var data = await _ctx.Repo<EntityOffice>().GetList();
            return ResultsOf<EntityOffice>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<EntityOffice>.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> Save([Body] EntityOffice info)
    {
        if (!_ctx.CheckPermission(PERMISSION.OFFICE_EDIT_SAVE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            if (info.Id > 0)
            {
                EntityOffice old = await _ctx.Repo<EntityOffice>().Query().FirstAsync(x => x.Id == info.Id);

                await _ctx.Repo<EntityOffice>().Update(info);
            }
            else
            {
                await _ctx.Repo<EntityOffice>().Insert(info);
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
        if (!_ctx.CheckPermission(PERMISSION.OFFICE_DELETE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            //var em = await GetInfoEmployee(_ctx.GuidEmployee);
            var item = await _ctx.Set<EntityOffice>().FindAsync(id);

            // kiểm tra chi nhánh đã áp dụng cho nhân sự chưa
            //var employees = await GetOptionEmployees();
            //var employeeByOffice = employees.Where(x => x._OfficeGuid == item.Guid).ToList();

            //if (employeeByOffice.Count() > 0)
            //    return Result.Error(_ctx.Text["The office has active employee, which cannot be deleted!", "Chi nhánh có nhân sự hoạt động, không thể xóa!"]);

            await _ctx.Repo<EntityOffice>().Remove(item);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> SetToPrimary(int id)
    {
        try
        {
            var item = await _ctx.Set<EntityOffice>().SingleOrDefaultAsync(x => x.Id == id);
            item.IsPrimary = !item.IsPrimary;

            await _ctx.Repo<EntityOffice>().Update(item);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }
    public async Task<Result> SetToActive(int id)
    {
        try
        {
            var item = await _ctx.Repo<EntityOffice>().GetOne(id);
            item.Active = !item.Active;

            await _ctx.Repo<EntityOffice>().Update(item);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<bool> CheckActiveUser(int id)
    {
        //if (_ctx.GuidEmployee == Guid.Empty)
        //    return false;

        //var item = await _ctx.Repo<EntityOffice>().GetOne(id);
        //var em = await GetInfoEmployee(_ctx.GuidEmployee);

        //if (em.OfficeGuid == item.Guid)
        //    return true;

        return false;
    }
}