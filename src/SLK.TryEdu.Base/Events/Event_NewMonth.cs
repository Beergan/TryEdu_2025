using System;
using MediatR;

namespace SLK.TryEdu.Base;

public class Event_NewMonth : INotification
{
    public DateTime Date { get; set; }
}