

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SLK.TryEdu.WebHost;

//[Authorize]
public class NotifyHub : Hub
{
    public Task Notify_1param(string evt, string p1)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1);
    }

    public Task Notify_2param(string evt, string p1, string p2)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2);
    }

    public Task Notify_3param(string evt, string p1, string p2, string p3)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2, p3);
    }

    public Task Notify_4param(string evt, string p1, string p2, string p3, string p4)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2, p3, p4);
    }

    public Task Notify_5param(string evt, string p1, string p2, string p3, string p4, string p5)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2, p3, p4, p5);
    }

    public Task Notify_6param(string evt, string p1, string p2, string p3, string p4, string p5, string p6)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2, p3, p4, p5, p6);
    }

    public Task Notify_7param(string evt, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
    {
        return MyContext.ProcessEvent(Context.ConnectionId, evt, p1, p2, p3, p4, p5, p6, p7);
    }

    public override async Task OnConnectedAsync()
    {
        await MyContext.SessionConnected(Context.ConnectionId, "BlazorWasm", Context.GetHttpContext()?.Connection.RemoteIpAddress.ToString() ?? "NA", Context.User?.Identity?.Name ?? "NA");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await MyContext.SessionDisconnect(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}