using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleEmployeeCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SLK.TryEdu.Base;
using System.Data;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SLK.TryEdu.ModuleEmployee;

public class EmployeeService : MyServiceBase, IEmployeeService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<EmployeeService> _log;
    private readonly string _ternantId;

    public EmployeeService(IMyContext ctx, ILogger<EmployeeService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }

    public async Task<ResultOf<EntityEmployee>> Get(Guid guid)
    {
        if (!_ctx.CheckPermission(PERMISSION.FILE_EMPLOYEE_VIEW))
            return ResultOf<EntityEmployee>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            var data = await _ctx.Repo<EntityEmployee>().Query(t => t.Guid == guid)
                .SingleOrDefaultAsync();

            return ResultOf<EntityEmployee>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return ResultOf<EntityEmployee>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<EntityEmployee>> GetList()
    {
        if (!_ctx.CheckPermission(PERMISSION.EMPLOYEE_VIEW))
            return ResultsOf<EntityEmployee>.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);
        try
        {
            var data = await _ctx.Repo<EntityEmployee>().GetList();

            return ResultsOf<EntityEmployee>.Ok(data);
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<EntityEmployee>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<ResultsOf<ModelEmployeeDocument>> GetListDocument()
    {
        try
        {
            var data = _ctx.Repo<EntityEmployeeDocument>().Query();
            var x = await data.GroupBy(x => x.FolderName)
                    .Select(x => new {
                        FolderName = x.Key,
                    }).ToListAsync();
            var y = x.Join(data, x => x.FolderName, data => data.FolderName, (x, data) => new ModelEmployeeDocument
            {
                FolderName = x.FolderName,
                Id = data.Id,
                Guid = data.Guid,
                GuidEmployee = data.GuidEmployee,
                GuidEmployeePost = data.GuidEmployeePost,
                NameEmployeePost = data.NameEmployeePost,
                NameFile = data.NameFile,
                TypeFile = data.TypeFile,
                DateCreated = data.DateCreated
            });
            return ResultsOf<ModelEmployeeDocument>.Ok(y);
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return ResultsOf<ModelEmployeeDocument>.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> Save([Body] EntityEmployee info)
    {
        if (!_ctx.CheckPermission(PERMISSION.EMPLOYEE_CREATE_UPDATE))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            if (info.Id > 0)
            {
                await _ctx.Repo<EntityEmployee>().Update(info);

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
                if(info.Guid == Guid.Empty)
                {
                    await _ctx.Repo<EntityEmployee>().Insert(info);
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

    public async Task<Result> SaveDocument([Body] ModelEmployeeDocument info)
    {
        try
        {
            Guid emGuid = _ctx.GuidEmployee;
            var userId = _ctx.UserId;
            var em = await GetInfoEmployee(_ctx.GuidEmployee);

            var item = new EntityEmployeeDocument();
            item.GuidEmployee = info.GuidEmployee;
            item.GuidEmployeePost = _ctx.GuidEmployee;
            item.NameFile = info.NameFile;
            item.TypeFile = info.TypeFile;
            item.FolderName = info.FolderName;
            item.GuidEmployeePost = em.Guid;
            item.NameEmployeePost = em.FullName;
            await _ctx.Repo<EntityEmployeeDocument>().Insert(item);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, _ctx.Summary);
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> DownloadDocument(string fileName)
    {
        
        var relativePath = $"/upload/{_ternantId}/document/{fileName}";
        var serverPath = $"{hostingEnv.ContentRootPath}wwwroot{relativePath}";

        return await Task.FromResult(Result.Ok());
    }

    public async Task<Result> DeleteDocument(int id)
    {
        try
        {
            var item = await _ctx.Set<EntityEmployeeDocument>().FindAsync(id);
            var Name = item.NameFile.GetAfterLast("/").Trim();
            var filePath = $"{hostingEnv.ContentRootPath}wwwroot/upload/{_ternantId}/document/{Name}";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            await _ctx.Repo<EntityEmployeeDocument>().Remove(item);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message);
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    public async Task<Result> SetToActiveEmployee(int id, Guid guidEmployee)
    {
        if (!_ctx.CheckPermission(PERMISSION.EMPLOYEE_ACTIVE_ACCOUNT))
            return Result.Error(_ctx.Text["You are not authorized!", "Bạn không có quyền!"]);

        try
        {
            var item = await _ctx.Repo<EntityEmployee>().GetOne(id);
            item.Active = !item.Active;
            await _ctx.Repo<EntityEmployee>().Update(item);

            var user = await _ctx.Set<SA_USER>().FirstOrDefaultAsync(x => x.GuidEmployee == guidEmployee);
            if (user != null)
            {
                user.Active = item.Active;
                _ctx.Set<SA_USER>().Update(user);
            }
            return Result.Ok();
        }
        catch (Exception ex)
        {
            _log.LogError($"{_ctx.Summary} - {ex.Message}");
            return Result.Error("Đã có lỗi xảy ra!");
        }
    }

    public Task<bool> CheckDocument()
    {
        return Task.FromResult(_ctx.CheckPermission(PERMISSION.EMPLOYEE_DOCUMENT));
    }
}