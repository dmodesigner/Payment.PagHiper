using System.Text.Json;
using System.Text;

namespace PagHiper.Services;

internal class HttpClientService<TResponse, TRequest> where TResponse : class
{
    private readonly HttpClient _httpClient;

    public HttpClientService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TResponse?> PostAsync(string url, TRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());

        throw new ArgumentException("Houve algum erro ao consumir a API do PagHiper.");
    }
}
