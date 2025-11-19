using SLK.TryEdu.Abstract;

public class TextTranslatorForServer : ITextTranslator
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMyCookie _cookie;
    private string langId = string.Empty;

    public TextTranslatorForServer(IHttpContextAccessor accessor, IMyCookie cookie)
    {
        _httpContextAccessor = accessor;
        _cookie = cookie;
        IRequestCookieCollection ckCollection = _httpContextAccessor.HttpContext?.Request.Cookies;
        
        string value = null;
        ckCollection?.TryGetValue(nameof(langId), out value);

        langId = value ?? "vi";
    }

    public string this[string str] 
    {
        get{
            if(string.IsNullOrEmpty(str))
                return str;

            string en = str.GetBefore("|");
            string vi = str.GetAfter("|");

            if (langId == "en")
                return en;

            return vi;
        }
    }

    public string this[string en, string vi] => langId == "en"? en : vi;

    public string CurrentLang => langId;

    public void SetLang(string lang)
    {
        _cookie.SetCookie(nameof(langId), lang);
        langId = lang;
    } 
}