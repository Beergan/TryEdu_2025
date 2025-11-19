using System;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

public interface IBlazorContext
{
    Func<string> PageTitle { get; set; }

    event Action<object[]> StateChanged;

    void NotifyStateChanged(params object[] evt);

    event Action<string, string[]> OnNotify;

    Task PublishEvent(string evt, params string[] data);

    Task<string> GetTheme();

    Task<string> SetTheme(string themeId);

    Task<string> GetAuthToken();

    INotifyService Notifier { get; }

    void UpdateBlazorPath(string path);
}