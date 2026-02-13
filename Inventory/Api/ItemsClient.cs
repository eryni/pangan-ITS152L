using System.Net.Http;
using System.Net.Http.Json;

namespace Inventory.Api;

public class ItemsClient
{
    private readonly HttpClient _http;

    public ItemsClient(string baseUrl, string username)
    {
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        if (!string.IsNullOrWhiteSpace(username))
            _http.DefaultRequestHeaders.Add("X-User", username);
    }

    public Task<Item[]?> GetAllAsync() => _http.GetFromJsonAsync<Item[]>("api/items");
    public Task<Item?> GetAsync(int id) => _http.GetFromJsonAsync<Item>($"api/items/{id}");

    public async Task<Item?> CreateAsync(Item item)
    {
        var res = await _http.PostAsJsonAsync("api/items", item);
        res.EnsureSuccessStatusCode();
        return await res.Content.ReadFromJsonAsync<Item>();
    }

    public async Task UpdateAsync(Item item)
    {
        var res = await _http.PutAsJsonAsync($"api/items/{item.Id}", item);
        res.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _http.DeleteAsync($"api/items/{id}");
        res.EnsureSuccessStatusCode();
    }
}
