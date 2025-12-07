using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Generators;
using RestEase;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleUserCore;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            using (var db = _ctx.ConnectDb())
            {
                var data = await db.Repo<EntityUser>().GetList();
                return ResultsOf<EntityUser>.Ok(data); 
            }
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
            using var db = _ctx.ConnectDb();

            var checkEmail = await db.Repo<EntityUser>().Query().FirstOrDefaultAsync(x => x.Email == info.Email && x.Id != info.Id);
            if (checkEmail != null)
            {
                return Result.Error("Email! đã tồn tại");
            }
            if (info.Id > 0)
            {
                await db.Repo<EntityUser>().Update(info);

                var user = await db.Repo<SA_USER>().Query().FirstOrDefaultAsync(x => x.GuidEmployee == info.Guid);
                if (user != null)
                {
                    user.LastName = info.LastName;
                    user.FirstName = info.FirstName;
                    user.Email = info.Email;
                    user.PhoneNumber = info.Phone;

                   await db.Repo<SA_USER>().Update(user);
                }
            }
            else
            {
                if (info.Guid == Guid.Empty)
                {
                   var newuser =  new EntityUser();
                    newuser.Guid = Guid.NewGuid(); 
                    newuser.Email = info.Email;
                    newuser.FirstName = info.FirstName;
                    newuser.LastName = info.LastName;
                    newuser.IsActive = info.IsActive;
                    newuser.IsVerified = info.IsVerified;
                    newuser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(info.PasswordHash);
                    newuser.Phone = info.Phone;
                    newuser.Address = info.Address;
                    newuser.HBD = info.HBD;
                    await db.Repo<EntityUser>().Insert(newuser);
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