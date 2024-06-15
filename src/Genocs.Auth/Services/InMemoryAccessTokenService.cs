using Genocs.Auth.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Genocs.Auth.Services;

internal sealed class InMemoryAccessTokenService : IAccessTokenService
{
    private readonly IMemoryCache _cache;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TimeSpan _expires;

    public InMemoryAccessTokenService(
                                        IMemoryCache cache,
                                        IHttpContextAccessor httpContextAccessor,
                                        JwtSettings jwtOptions)
    {
        _cache = cache;
        _httpContextAccessor = httpContextAccessor;
        _expires = jwtOptions.Expiry ?? TimeSpan.FromMinutes(jwtOptions.ExpiryMinutes);
    }

    public Task<bool> IsCurrentActiveToken()
        => IsActiveAsync(GetCurrentAsync());

    public Task DeactivateCurrentAsync()
        => DeactivateAsync(GetCurrentAsync());

    public Task<bool> IsActiveAsync(string token)
        => Task.FromResult(string.IsNullOrWhiteSpace(_cache.Get<string>(GetKey(token))));

    public Task DeactivateAsync(string token)
    {
        _cache.Set(GetKey(token), "revoked", new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = _expires
        });

        return Task.CompletedTask;
    }

    private string GetCurrentAsync()
    {
        var authorizationHeader = _httpContextAccessor
            .HttpContext?.Request.Headers["authorization"];

        if (authorizationHeader is null)
        {
            return string.Empty;
        }

        return authorizationHeader.Value == StringValues.Empty
            ? string.Empty
            : authorizationHeader.Value.Single().Split(' ').Last();
    }

    private static string GetKey(string token) => $"blacklisted-tokens:{token}";
}