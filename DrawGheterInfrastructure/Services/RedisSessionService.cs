namespace DrawGheterInfrastructure.Services;

using StackExchange.Redis;
using System.Text.Json;

public class RedisSessionService(IConnectionMultiplexer redis)
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task SaveSessionAsync(string sessionId, object sessionData, TimeSpan ttl)
    {
        var json = JsonSerializer.Serialize(sessionData);
        await _db.StringSetAsync($"session:{sessionId}", json, ttl);
    }

    public async Task<T?> GetSessionAsync<T>(string sessionId)
    {
        string? value = await _db.StringGetAsync($"session:{sessionId}");

        return value is null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public async Task RemoveSessionAsync(string sessionId)
    {
        await _db.KeyDeleteAsync($"session:{sessionId}");
    }
}