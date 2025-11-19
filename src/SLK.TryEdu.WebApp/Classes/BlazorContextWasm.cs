using Microsoft.AspNetCore.SignalR.Client;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.WebApp;

public class BlazorContextWasm : IBlazorContext
{
    private CancellationTokenSource _cts = new CancellationTokenSource();
    private readonly IAuthService _authSvc;
    private readonly HubConnection _hubConn;
    private readonly IMyCookie _cookie;
    private readonly INotifyService _notifier;

    public BlazorContextWasm(IAuthService authSvc, HubConnection hubConn, IMyCookie cookie, INotifyService notify)
    {
        _authSvc = authSvc;
        _hubConn = hubConn;
        _cookie = cookie;
        _notifier = notify;

        _hubConn.Closed += error => { return ConnectWithRetryAsync(_cts.Token); };
        _hubConn.On<string, string[]>("Notify", (evt, data) => OnNotify?.Invoke(evt, data));

#pragma warning disable CS4014
        this.ConnectWithRetryAsync(_cts.Token);

    }

    private async Task<bool> ConnectWithRetryAsync(CancellationToken token)
    {
        // Keep trying to until we can start or the token is canceled.
        while (true)
        {
            try
            {
                await _hubConn.StartAsync(token);
                return true;
            }
            catch when (token.IsCancellationRequested)
            {
                return false;
            }
            catch
            {
                // Try again in a few seconds. This could be an incremental interval           
                await Task.Delay(5000);
            }
        }
    }

    public Task PublishEvent(string evt, params string[] data)
    {
        return Task.CompletedTask;
    }

    public Task NotifyEvent(string evt, params string[] data)
    {
        switch (data.Length)
        {
            case 1:
                return _hubConn.SendAsync("Notify_1param", evt, data[0]);
            case 2:
                return _hubConn.SendAsync("Notify_2param", evt, data[0], data[1]);
            case 3:
                return _hubConn.SendAsync("Notify_3param", evt, data[0], data[1], data[2]);
            case 4:
                return _hubConn.SendAsync("Notify_4param", evt, data[0], data[1], data[2], data[3]);
            case 5:
                return _hubConn.SendAsync("Notify_5param", evt, data[0], data[1], data[2], data[3], data[4]);
            case 6:
                return _hubConn.SendAsync("Notify_6param", evt, data[0], data[1], data[2], data[3], data[4], data[5]);
            case 7:
                return _hubConn.SendAsync("Notify_7param", evt, data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
        }

        return Task.CompletedTask;
    }

    public event Action<string, string[]>? OnNotify;

    private Func<string> _pageTitle;
    public Func<string> PageTitle
    {
        get { return _pageTitle; }
        set
        {
            _pageTitle = value;
            NotifyStateChanged();
        }
    }

    public async Task<string> GetAuthToken()
    {
        return await _cookie.GetCookie("Auth");
    }

    public event Action<object[]> StateChanged;

    public void NotifyStateChanged(params object[] evt)
    {
        StateChanged.Invoke(evt);
    }

    private string _theme = null;
    public async Task<string> GetTheme()
    {
        return _theme ?? (_theme = await _cookie.GetCookie("ThemeId", ""));
    }

    public async Task<string> SetTheme(string themeId)
    {
        _theme = themeId;
        await _cookie.SetCookie("ThemeId", themeId, 30);
        NotifyStateChanged();
        return themeId;
    }

    public void UpdateBlazorPath(string path)
    {
        NotifyEvent("UPDATE_BLAZOR_PATH", path);
    }

    public INotifyService Notifier => _notifier;
}