using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleEmployeeCore;

namespace SLK.TryEdu.ModuleEmployee;

public class QryHandlerOptionEmployees : MyServiceBase, IRequestHandler<QueryOptionEmployees, List<OptionItem<Guid>>>
{
    public QryHandlerOptionEmployees(IMyContext ctx) : base(ctx)
    {

    }

    public async Task<List<OptionItem<Guid>>> Handle(QueryOptionEmployees request, CancellationToken cancellationToken)
    {
        return await _ctx.Repo<EntityEmployee>()
            .Query()
            .Select(x => new OptionItem<Guid> { Value = x.Guid, Text = x.FullName})
            .ToListAsync();
    }
}