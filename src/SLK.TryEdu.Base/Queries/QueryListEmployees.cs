using System;
using System;
using System.Collections.Generic;
using MediatR;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class QueryListEmployees :  IRequest<List<ModelInfoEmployee>>
{
}