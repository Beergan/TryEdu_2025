using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.WebHost;

public class SessionId : ISessionId
{
    private Guid _value = Guid.NewGuid();

    public string Value => _value.ToString();
}