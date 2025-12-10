using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLK.TryEdu.Base;

public class MyServiceBase : IServiceBase
{
    protected readonly IMyContext _ctx;

    public MyServiceBase(IMyContext ctx)
    {
        _ctx = ctx;
    }

    /// <summary>
    /// Lấy danh sách entity với cache tự động: nếu có cache thì lấy từ cache, không có thì query DB và lưu cache
    /// </summary>
    protected async Task<ResultsOf<T>> GetListWithCache<T>() where T : class
    {
        try
        {
            using (var db = _ctx.ConnectDb())
            {
                var data = await _ctx.Cache<T>().GetListWithCache();
                return ResultsOf<T>.Ok(data);
            }
        }
        catch (Exception ex)
        {
            return ResultsOf<T>.Error($"Đã có lỗi xảy ra: {ex.Message}");
        }
    }

    /// <summary>
    /// Xóa cache của entity sau khi có thay đổi (Insert/Update/Delete)
    /// </summary>
    protected void ClearCache<T>() where T : class
    {
        try
        {
            // IMyContext có method Cache, không phải IDbContext
            _ctx.Cache<T>().ClearCache();
        }
        catch
        {
            // Ignore cache clear errors
        }
    }

    [HttpGet]
    public Task<List<KeyValuePair<FeatureModel, Tuple<long, string, string>[]>>> GetListPermissions()
    {
        var list = GlobalPermissions.Dictionary.ToList();
        return Task.FromResult(list);
    }

    [HttpGet]
    public Task<List<OptionItem<Guid>>> GetOptionOffices()
    {
        return _ctx.Mediator.Send(new QueryOptionOffices());
    }

    [HttpGet]
    public Task<List<OptionItem<Guid>>> GetOptionJob()
    {
        return _ctx.Mediator.Send(new QueryOptionJob());
    }

    [HttpGet]
    public Task<OptionItem<Guid>> GetOptionCompany()
    {
        return _ctx.Mediator.Send(new QueryOptionCompany());
    }

    [HttpGet]
    public Task<ModelInfoEmployee> GetInfoEmployee(Guid guid)
    {
        return _ctx.Mediator.Send(new QueryInfoEmployee { Guid = guid });
    }
    [HttpGet]
    public Task<List<ModelListCustomer>> GetlistCustomer()
    {
        return _ctx.Mediator.Send(new QueryListCustomer());
    }
    [HttpGet]
    public Task<List<ModelService>> GetListService()
    {
        return _ctx.Mediator.Send(new QueryListService());
    }
    [HttpGet]
    public Task<ModelListCustomer> GetInforCustomer(Guid guid)
    {
        return _ctx.Mediator.Send(new QueryInforCustomer { Guid = guid });
    }

}