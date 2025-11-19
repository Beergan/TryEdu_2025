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

public class QryHandlerOptionCompany : IRequestHandler<QueryOptionCompany, OptionItem<Guid>>
{
    private readonly IMyContext _ctx;

    public QryHandlerOptionCompany(IMyContext ctx)
    {
        _ctx = ctx;
    }

    public Task<OptionItem<Guid>> Handle(QueryOptionCompany request, CancellationToken cancellationToken)
    {
        return _ctx.Repo<EntityCompany>()
            .Query()
            .Select(x => new OptionItem<Guid> { Value = x.Guid, Text = x.CompanyName, Attributes = x.CompanyLogo})
            .FirstOrDefaultAsync();
    }
}