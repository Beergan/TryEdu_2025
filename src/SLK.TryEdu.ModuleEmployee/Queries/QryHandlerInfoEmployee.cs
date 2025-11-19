using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleEmployeeCore;


namespace SLK.TryEdu.ModuleEmployee;

public class QryHandlerInfoEmployee : IRequestHandler<QueryInfoEmployee, ModelInfoEmployee>
{
    private readonly IMyContext _ctx;
    public QryHandlerInfoEmployee(IMyContext ctx)
    {
        _ctx = ctx;
    }
    public Task<ModelInfoEmployee> Handle(QueryInfoEmployee request, CancellationToken cancellationToken)
    {
        return _ctx.Repo<EntityEmployee>()
            .Query(x => x.Guid == request.Guid)
            .Select(x => new ModelInfoEmployee
            {
                Guid = x.Guid,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FullName,
                Gender = x.Gender,
                Phone = x.Phone,
                Email = x.Email,
                OfficeGuid = x.OfficeGuid,
                OfficeName = x.OfficeName,
                Avatar = x.Avatar,
                JobGuid = x.JobGuid,
            })
            .FirstOrDefaultAsync();
    }
}