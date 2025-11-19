using Microsoft.AspNetCore.Components.Server.Circuits;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.WebHost;

public class CircuitHandlerService : CircuitHandler
{
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly ISessionId _sessionId;

    public CircuitHandlerService(IHttpContextAccessor accessor, ISessionId sessionId)
    {
        _httpAccessor = accessor;
        _sessionId = sessionId;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        var userId = _httpAccessor.HttpContext?.User.Identity?.Name ?? "NA";
        var ipAddress = _httpAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        MyContext.SessionConnected(_sessionId.Value, "BlazorServer", ipAddress, userId);

        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
        MyContext.SessionDisconnect(_sessionId.Value);
        return base.OnCircuitClosedAsync(circuit, cancellationToken);
    }
}