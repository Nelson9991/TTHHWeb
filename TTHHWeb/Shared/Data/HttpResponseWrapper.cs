namespace TTHHWeb.Shared.Data;

public class HttpResponseWrapper<T>
{
    public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
    {
        Response = response;
        Error = error;
        HttpResponseMessage = httpResponseMessage;
    }

    public bool Error { get; set; }
    public T? Response { get; set; }
    public HttpResponseMessage HttpResponseMessage { get; set; }

    public async Task<string> GetResponseBodyAsync()
    {
        return await HttpResponseMessage.Content.ReadAsStringAsync();
    }
}
