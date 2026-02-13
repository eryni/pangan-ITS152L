using System.Net.Http;
using System.Net.Http.Json;

namespace Inventory.Api;

public class LogsClient
{
    private readonly HttpClient _http;

    public LogsClient(string baseUrl, string username)
    {
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        if (!string.IsNullOrWhiteSpace(username))
            _http.DefaultRequestHeaders.Add("X-User", username);
    }

    public Task<LogEntry[]?> GetAllAsync() =>
        _http.GetFromJsonAsync<LogEntry[]>("api/logs");
}
