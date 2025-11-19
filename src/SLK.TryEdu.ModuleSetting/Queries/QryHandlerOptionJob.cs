using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;
using Syncfusion.Blazor.PivotView;

namespace SLK.TryEdu.ModuleSetting;

public class QryHandlerOptionJob : IRequestHandler<QueryOptionJob, List<OptionItem<Guid>>>
{
    private readonly IMyContext _ctx;

    public QryHandlerOptionJob(IMyContext ctx)
    {
        _ctx = ctx;
    }

    public Task<List<OptionItem<Guid>>> Handle(QueryOptionJob request, CancellationToken cancellationToken)
    {
        return _ctx.Repo<EntityJob>()
            .Query()
            .Select(x => new OptionItem<Guid> { Value = x.Guid, Text = x.JobName})
            .ToListAsync();
    }
}