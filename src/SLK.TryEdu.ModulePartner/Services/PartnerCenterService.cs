using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModulePartnerCore;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SLK.TryEdu.ModulePartner; 

public class PartnerCenterService : MyServiceBase, IPartnerCenterService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<PartnerCenterService> _log;
    private readonly string _ternantId;

    public PartnerCenterService(IMyContext ctx, ILogger<PartnerCenterService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
     Task<ResultOf<EntityPartnerCenter>> IPartnerCenterService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    public async  Task<ResultsOf<EntityPartnerCenter>> GetList()
    {
        if (!_ctx.CheckPermission(PERMISSION.PARTNER_VIEW))
            return ResultsOf<EntityPartnerCenter>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            using (var db = _ctx.ConnectDb())
            {
                var data = await db.Repo<EntityPartnerCenter>().GetList();
                return ResultsOf<EntityPartnerCenter>.Ok(data);
            }
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<EntityPartnerCenter>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> Save([Body] EntityPartnerCenter info)
    {
        if (!_ctx.CheckPermission(PERMISSION.PARTNER_CREATE_UPDATE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            using var db = _ctx.ConnectDb();
            var checkEmail = await db.Repo<EntityPartnerCenter>().Query().FirstOrDefaultAsync(x => x.Email == info.Email && x.Id != info.Id);
            if (checkEmail != null)
            {
                return Result.Error("Email! đã tồn tại");
            }
            if (info.Id > 0)
            {
                await db.Repo<EntityPartnerCenter>().Update(info);
            }
            else
            {
                if (info.Guid == Guid.Empty)
                {
                    await db.Repo<EntityPartnerCenter>().Insert(info);
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