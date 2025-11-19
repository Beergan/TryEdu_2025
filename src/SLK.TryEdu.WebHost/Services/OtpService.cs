using Microsoft.Extensions.Caching.Memory;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.WebHost.Services;

public interface IOtpService
{
    string GenerateOtp(string userId);
    bool VerifyOtp(string userId, string otp);
    bool CheckOtpExists(string userId);
    DateTime? GetOtpExpiryTime(string userId); 
    string MaskEmail(string email);
    void RemoveOtp(string userId);
}

public class OtpService : IOtpService
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<OtpService> _logger;

    public OtpService(IMemoryCache cache, ILogger<OtpService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public string GenerateOtp(string userId)
    {
        var random = new Random();
        var otp = random.Next(0, 1000000).ToString("D6");
        var cacheKey = $"OTP_{userId}";
        var expiryKey = userId;
        var expiryTime = DateTime.UtcNow.AddMinutes(1); 

        _cache.Set(cacheKey, otp, TimeSpan.FromMinutes(5));
        _cache.Set(expiryKey, expiryTime, TimeSpan.FromMinutes(2)); 
        _cache.Set(userId, userId, TimeSpan.FromMinutes(1));

        _logger.LogInformation($"Generated OTP for user {userId}: {otp}, expires at {expiryTime}");
        return otp;
    }

    public bool CheckOtpExists(string userId)
    {
        var cacheuserId = userId;
        return _cache.TryGetValue(cacheuserId, out _);
    }

    public bool VerifyOtp(string userId, string otp)
    {
        var cacheKey = $"OTP_{userId}";
        if (_cache.TryGetValue(cacheKey, out string cachedOtp))
        {
            return cachedOtp == otp;
        }
        return false;
    }

    public DateTime? GetOtpExpiryTime(string userId)
    {
        var expiryKey = $"OTP_EXPIRY_{userId}";
        if (_cache.TryGetValue(expiryKey, out DateTime expiryTime))
        {
            return expiryTime;
        }
        return null;
    }
    public string MaskEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return "";
        var parts = email.Split('@');
        if (parts.Length != 2) return email;

        var username = parts[0];
        var domain = parts[1];

        if (username.Length <= 2)
            return $"{username}***@{domain}";

        return $"{username.Substring(0, 2)}***@{domain}";
    }

    public void RemoveOtp(string userId)
    {
        var cacheKey = $"OTP_{userId}";
        var expiryKey = userId;

        _cache.Remove(cacheKey);
        _cache.Remove(expiryKey); 
        _cache.Remove(userId);
    }
}