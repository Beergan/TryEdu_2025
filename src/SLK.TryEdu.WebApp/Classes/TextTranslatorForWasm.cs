using SLK.TryEdu.Abstract;

public class TextTranslatorForWasm : ITextTranslator
{
    private readonly IMyCookie _cookie;
    private string langId = string.Empty;

    public TextTranslatorForWasm(IMyCookie cookie, string lang)
    {
        langId = lang ?? "vi";
        _cookie = cookie;
    }

    public string this[string en, string vi] => langId == "en" ? en : vi;

    public string this[string str]
    {
        get
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string en = str.GetBefore("|");
            string vi = str.GetAfter("|");

            if (langId == "en")
                return en;

            return vi;
        }
    }

    public string CurrentLang => langId;

    public void SetLang(string lang)
    {
        _cookie.GetCookie(nameof(langId), lang);
        langId = lang;
    }
}