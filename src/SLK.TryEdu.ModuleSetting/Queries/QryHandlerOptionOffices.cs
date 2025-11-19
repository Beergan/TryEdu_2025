using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;

namespace SLK.TryEdu.ModuleSetting;

public class QryHandlerOptionOffices : IRequestHandler<QueryOptionOffices, List<OptionItem<Guid>>>
{
    private readonly IMyContext _ctx;

    public QryHandlerOptionOffices(IMyContext ctx)
    {
        _ctx = ctx;
    }

    public Task<List<OptionItem<Guid>>> Handle(QueryOptionOffices request, CancellationToken cancellationToken)
    {
        return _ctx.Repo<EntityOffice>()
            .Query(x => x.Active)
            .Select(x => new OptionItem<Guid> { Value = x.Guid, Text = x.Name, IsPrimary = x.IsPrimary, Avatar = x.Avatar, Address = x.Address, Phone = x.Phone})
            .ToListAsync();
    }
}