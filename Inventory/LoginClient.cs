using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Inventory.Api
{
    public class LoginClient
    {
        private readonly HttpClient _http;

        public LoginClient(string baseUrl)
        {
            _http = new HttpClient { BaseAddress = new System.Uri(baseUrl) };
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var res = await _http.PostAsJsonAsync("api/auth/login", new { Username = username, Password = password });
            return res.IsSuccessStatusCode;
        }
    }
}
