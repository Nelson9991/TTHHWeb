using System.Net.Http.Json;
using System.Text.Json;
using TTHHWeb.Shared.Data.Repository.IRepository;

namespace TTHHWeb.Shared.Data.Repository;

public class HttpRepository : IHttpRepository
{
    private readonly JsonSerializerOptions _defaultSerializerOptions =
        new() { PropertyNameCaseInsensitive = true };

    private readonly HttpClient _http;

    public HttpRepository(HttpClient http)
    {
        _http = http;
    }

    public async Task<HttpResponseWrapper<string>> Get(string url, bool includeToken = false)
    {
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<string>(default, true, response);

        return new HttpResponseWrapper<string>(
            await response.Content.ReadAsStringAsync(),
            false,
            response
        );
    }

    public async Task<HttpResponseWrapper<T>> GetFromJsonAsync<T>(
        string url,
        bool includeToken = false
    )
    {
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<T>(default, true, response);

        var deserializedResp = await DeserializeResponse<T>(response, _defaultSerializerOptions);

        return new HttpResponseWrapper<T>(deserializedResp, false, response);
    }

    public async Task<HttpResponseWrapper<object>> PostAsJson<T>(string url, T resource)
    {
        var response = await _http.PostAsJsonAsync(url, resource);
        return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
    }

    public async Task<HttpResponseWrapper<TResponse>> PostAsJson<T, TResponse>(
        string url,
        T resource
    )
    {
        var response = await _http.PostAsJsonAsync(url, resource);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<TResponse>(default, true, response);

        var deserializedResponse = await DeserializeResponse<TResponse>(
            response,
            _defaultSerializerOptions
        );

        return new HttpResponseWrapper<TResponse>(deserializedResponse, false, response);
    }

    public async Task<HttpResponseWrapper<object>> PostAsJsonAndReturnRawResponse<T>(
        string url,
        T resource
    )
    {
        var response = await _http.PostAsJsonAsync(url, resource);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<object>(default, true, response);

        return new HttpResponseWrapper<object>(default, false, response);
    }

    public async Task<HttpResponseWrapper<TResponse>> Post<TResponse>(
        string url,
        HttpContent content
    )
    {
        var response = await _http.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<TResponse>(default, true, response);

        var deserializedResponse = await DeserializeResponse<TResponse>(
            response,
            _defaultSerializerOptions
        );

        return new HttpResponseWrapper<TResponse>(deserializedResponse, false, response);
    }

    public async Task<HttpResponseWrapper<TResponse>> PutAsJson<T, TResponse>(
        string url,
        T resource
    )
    {
        var response = await _http.PutAsJsonAsync(url, resource);
        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<TResponse>(default, true, response);

        var deserializedResponse = await DeserializeResponse<TResponse>(
            response,
            _defaultSerializerOptions
        );

        return new HttpResponseWrapper<TResponse>(deserializedResponse, false, response);
    }

    public async Task<HttpResponseWrapper<object>> PutAsJson<T>(string url, T resource)
    {
        var response = await _http.PutAsJsonAsync(url, resource);
        return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
    }

    public async Task<HttpResponseWrapper<object>> Delete(string url)
    {
        var response = await _http.DeleteAsync(url);
        return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
    }

    public async Task<HttpResponseWrapper<TResponse>> Delete<TResponse>(string url)
    {
        var response = await _http.DeleteAsync(url);

        if (!response.IsSuccessStatusCode)
            return new HttpResponseWrapper<TResponse>(default, true, response);

        var deserializedResponse = await DeserializeResponse<TResponse>(
            response,
            _defaultSerializerOptions
        );

        return new HttpResponseWrapper<TResponse>(deserializedResponse, false, response);
    }

    private static async Task<T?> DeserializeResponse<T>(
        HttpResponseMessage httpResponseMessage,
        JsonSerializerOptions jsonSerializerOptions
    )
    {
        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
    }
}
