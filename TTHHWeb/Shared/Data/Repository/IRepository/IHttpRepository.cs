using TTHHWeb.Shared.Data;

namespace TTHHWeb.Shared.Data.Repository.IRepository;

public interface IHttpRepository
{
    Task<HttpResponseWrapper<T>> GetFromJsonAsync<T>(string url, bool includeToken = false);

    Task<HttpResponseWrapper<object>> PostAsJson<T>(string url, T resource);

    Task<HttpResponseWrapper<TResponse>> PostAsJson<T, TResponse>(string url, T resource);

    Task<HttpResponseWrapper<object>> PostAsJsonAndReturnRawResponse<T>(string url, T resource);

    Task<HttpResponseWrapper<TResponse>> Post<TResponse>(string url, HttpContent content);

    Task<HttpResponseWrapper<object>> PutAsJson<T>(string url, T resource);

    Task<HttpResponseWrapper<TResponse>> PutAsJson<T, TResponse>(string url, T resource);

    Task<HttpResponseWrapper<object>> Delete(string url);

    Task<HttpResponseWrapper<TResponse>> Delete<TResponse>(string url);

    Task<HttpResponseWrapper<string>> Get(string url, bool includeToken = false);
}
