using System;
using MediatR;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class QueryInfoEmployee : IRequest<ModelInfoEmployee>
{
    public Guid Guid { get; set; }
}