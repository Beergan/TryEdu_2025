using System;
using System.Collections.Generic;
using MediatR;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class QueryInforCustomer : IRequest<ModelListCustomer>
{
    public Guid Guid { get; set; }
    public string Id { get; set; }
}