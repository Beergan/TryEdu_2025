using Newtonsoft.Json;
using SLK.TryEdu.Abstract;
using System.Net.Http.Json;

namespace SLK.TryEdu.WebApp;

public class WasmAuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private InfoUser _currentUser;

    public WasmAuthService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient();
    }

    public InfoUser CurrentUser => _currentUser;

    public async Task<RspLogin> Login(LoginRequest loginRequest)
    {
        try
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginRequest);
            var resultText = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode == false)
                return new RspLogin(resultText);

            return JsonConvert.DeserializeObject<RspLogin>(resultText)!;
        }
        catch (Exception ex)
        {
            return new RspLogin(ex.Message);
        }
    }

    public async Task<Tuple<bool, string>> Logout()
    {
        try
        {
            var result = await _httpClient.GetAsync("api/Auth/Logout");
            var resultText = await result.Content.ReadAsStringAsync();
            _currentUser = null;

            if (result.IsSuccessStatusCode == false)
                return new Tuple<bool, string>(result.IsSuccessStatusCode, resultText);

            return JsonConvert.DeserializeObject<Tuple<bool, string>>(resultText)!;
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }

    public async Task<InfoUser> ValidateTokenInCookie()
    {
        if (_currentUser != null)
            return _currentUser;

        try
        {
            _currentUser = await _httpClient.GetFromJsonAsync<InfoUser>("api/Auth/ValidateTokenInCookie");
        }
        catch (Exception ex) 
        {
            Console.WriteLine("ValidateTokenInCookie failed! " + ex.Message);
        }

        return _currentUser ?? new InfoUser();
    }
}