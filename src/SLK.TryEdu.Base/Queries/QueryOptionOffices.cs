using System;
using System.Collections.Generic;
using MediatR;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class QueryOptionOffices : IRequest<List<OptionItem<Guid>>>
{
}