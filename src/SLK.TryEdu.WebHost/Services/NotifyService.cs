using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.Abstract;
using System.Collections.Concurrent;

namespace SLK.TryEdu.WebHost;

public class NotifyService : INotifyService
{
    private readonly ILogger<NotifyService> _log;
    private static ConcurrentQueue<ModelNotification> _notifyQueue = new();
    private const int _notifyPoolSize = 10;

    public NotifyService(ILogger<NotifyService> log)
    {
        _log = log;
    }

    [HttpPost]
    public async Task<Result> AddNotify(string content, string href)
    {
        while (_notifyQueue.Count >= _notifyPoolSize)
        {
            _notifyQueue.TryDequeue(out var x);
        }

         _notifyQueue.Enqueue(new() { Message = content, Href = href, NotityTime = DateTime.Now });

        MyContext.PublishEventStatic("GOT_NEW_NOTIFICATION");

        return Result.Ok();
    }

    [HttpGet]
    public async Task<ResultsOf<ModelNotification>> GetNotifies()
    {
        return _notifyQueue.Reverse().ToList();
    }
}