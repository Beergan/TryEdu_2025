using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.Db;
using System.Collections.Concurrent;
using System.Reflection;
using System.Security.Claims;

namespace SLK.TryEdu.WebHost;

public class MyContext : IMyContext, IBlazorContext
{
    public MyContext(IServiceProvider provider,
        Func<IDbContext> dbFactory,
        IHttpContextAccessor accessor,
        Func<CacheMode, ICacheService> cacheMode,
        IMyCookie cookie,
        INotifyService notifier,
        ISessionId sessionId
        )
    {
        _provider = provider;
        _dbFactory = dbFactory;
        _httpContext = accessor.HttpContext;
        _cacheMode = cacheMode;
        _cookie = cookie;
        _notifier = notifier;
        _sessionId = sessionId;
    }

    private Func<CacheMode, ICacheService> _cacheMode;
    private Func<IDbContext> _dbFactory;
    private readonly IServiceProvider _provider;
    private readonly HttpContext _httpContext;
    private readonly IMyCookie _cookie;
    private static ConcurrentDictionary<string, BlazorSession> _sessions = new();
    private static event Action<string, string[]> _eventNotify;
    private readonly INotifyService _notifier;
    private readonly ISessionId _sessionId;

    [JsonIgnore]
    public HttpContext HttpContext => _httpContext;

    public IDbContext ConnectDb()
    {
        var dbContext = _dbFactory.Invoke();

        dbContext.IpAddress = this.IpAddress;
        dbContext.UserId = this.UserId;

        return dbContext;
    }

    private IDbContext _db;
    [JsonIgnore]
    public IDbContext Db => _db ?? (_db = _dbFactory.Invoke());

    public IDatabaseTransaction BeginTransaction()
    {
        var dbContext = _dbFactory.Invoke();
        dbContext.IpAddress = IpAddress;
        dbContext.UserId = UserId;

        return new EntityDatabaseTransaction(dbContext);
    }

    public IDatabaseTransaction BeginTransaction(string userId)
    {
        var dbContext = _dbFactory.Invoke();
        dbContext.IpAddress = "PL-TOS";
        dbContext.UserId = userId;

        return new EntityDatabaseTransaction(dbContext);
    }

    [JsonIgnore]
    public ICollection<BlazorSession> BlazorSessions => _sessions.Values;

    public DbSet<T> Set<T>() where T : class
    {
        return Db.Set<T>();
    }

    public IRepository<T> Repo<T>() where T : class
    {
        return new BaseRepository<T>(Db);
    }

    public ICacheRepository<T> Cache<T>() where T : class
    {
        return new CacheRepository<T>(Db, _cacheMode);
    }

    public bool CheckPermission<T>(params T[] requiredClaims) where T : Enum
    {
        IEnumerable<Claim> userClaims = _httpContext.User?.Claims ?? null;
        if (userClaims == null) return false;

        var featureAttrb = requiredClaims[0].GetType().GetCustomAttribute<FeatureAttribute>();
        if (featureAttrb == null) return false;

        long requiredPermission = Convert.ToInt64(requiredClaims.Select(x => (long)Math.Pow(2, Convert.ToInt64(x))).Sum());
        List<long> availablePermissionLst = userClaims
            .Where(x => x.Type == featureAttrb.Name)
            .Select(x => Convert.ToInt64(x.Value))
            .ToList();
        foreach (var availablePermission in availablePermissionLst)
        {
            if (availablePermission == 0) continue;

            if ((availablePermission & requiredPermission) == requiredPermission) return true;
        }
        return false;
    }

    public string IpAddress => _httpContext?.Connection?.RemoteIpAddress?.ToString() ?? "NA";

    public string UserAgent => _httpContext?.Request.Headers["User-Agent"] ?? "NA";

    //public AppManifest AppManifest => GlobalSetingCommon._AppManifest.FirstOrDefault(x => x.EnterpriseCode == this.EnterpriseCode) ?? new();

    public string UserId => _httpContext?.User.Identity?.Name ?? "NA";

    public string EnterpriseCode => _httpContext?.User.Claims.FirstOrDefault(x => x.Type == "EnterpriseCode")?.Value ?? "MPD";

    public string BlazorPath
    {
        get
        {
            return _sessions.ContainsKey(_sessionId.Value) ? _sessions[_sessionId.Value].Path : "NA";
        }
    }

    public SA_USER GetCurrentUser()
    {
        using (var db = this.ConnectDb())
        {
            return db.Set<SA_USER>().AsNoTracking().FirstOrDefault(x => x.UserName == UserId);
        }
    }

    public T GetService<T>()
    {
        return _provider.GetService<T>();
    }

    [JsonIgnore]
    public ITextTranslator Text => _provider.GetRequiredService<ITextTranslator>();

    [JsonIgnore]
    public IMediator Mediator => _provider.GetRequiredService<IMediator>();

    //[JsonIgnore]
    //public IWorkFlowService Workflow => _provider.GetRequiredService<IWorkFlowService>();

    [JsonIgnore]
    public string Summary => JsonConvert.SerializeObject(this);

    [JsonIgnore]
    public INotifyService Notifier => _notifier;

    public event Action<string, string[]> OnNotify
    {
        add { _eventNotify += value; }
        remove { _eventNotify -= value; }
    }

    public static Task SessionConnected(string sessionId, string connType, string ipAddress, string userId)
    {
        if (_sessions.ContainsKey(sessionId))
            _sessions[sessionId].UserId = userId;
        else
        {
            var session = new BlazorSession();
            session.SessionId = sessionId;
            session.UserId = userId;
            session.ConnType = connType;
            session.IpAddress = ipAddress;
            session.Begin = DateTime.UtcNow;

            _sessions[sessionId] = session;
        }

        return Task.CompletedTask;
    }

    public static Task SessionDisconnect(string sessionId)
    {
        BlazorSession sessionDisconnected;
        _sessions.TryRemove(sessionId, out sessionDisconnected);
        if (sessionDisconnected != null)
        {
            //OnUserRemoved(circuitRemoved.UserId);
            //OnCircuitsChanged();
            PublishEventStatic("USER_DISCONNETED", sessionId, $"User {sessionDisconnected.UserId} vừa thoát ra!");
        }

        return Task.CompletedTask;
    }

    public static Task ProcessEvent(string sessionId, string evt, params string[] data)
    {
        switch (evt)
        {
            case "UPDATE_BLAZOR_PATH":
                if (_sessions.ContainsKey(sessionId))
                    _sessions[sessionId].Path = data[0];
                break;
        }

        _eventNotify?.Invoke(evt, data);
        return Task.CompletedTask;
    }

    public static void PublishEventStatic(string evt, params string[] data)
    {
        _eventNotify?.Invoke(evt, data);

        var hub = StaticResolver.Resolve<IHubContext<NotifyHub>>();
        hub.Clients.All.SendAsync("Notify", evt, data);
    }

    public Task PublishEvent(string evt, params string[] data)
    {
        return MyContext.ProcessEvent(_sessionId.Value.ToString(), evt, data);
    }

    private Func<string> _pageTitle;
    [JsonIgnore]
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
        StateChanged?.Invoke(evt);
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
        _sessions[_sessionId.Value].Path = path;
    }

    private bool _IsFreeze = false;
    public async Task<bool> GetFreeze(string NameCookie)
    {
        string bools = await _cookie.GetCookie(NameCookie, "");
        if (bools == null || bools =="")
        {
            return false;
        }
        return _IsFreeze = bool.Parse(await _cookie.GetCookie(NameCookie, ""));
    }

    public async Task<string> SetFreeze(string NameCookie, string ValueCookie)
    {
        await _cookie.SetCookie(NameCookie, ValueCookie, 30);
        NotifyStateChanged();

        return ValueCookie;
    }

    public Guid GuidEmployee
    {
        get
        {
            IEnumerable<Claim> userClaims = _httpContext?.User?.Claims;
            if (userClaims == null) return Guid.Empty;

            Guid? guid = userClaims
                .Where(c => c.Type == nameof(GuidEmployee))
                .Select(c => Guid.Parse(c.Value))
                .FirstOrDefault();

            return guid ?? Guid.Empty;
        }

    }
}