using Dayana.Shared.Infrastructure.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.HttpObjects;
public class HttpService : IHttpService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public HttpService(HttpClient client, JsonSerializerOptions options)
    {
        _client = client;
        _options = options;
    }

    public async Task<T> GetValue<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);

        var content = await response.Content.ReadAsStreamAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception("bad request | maybe wrong address");

        return await JsonSerializer.DeserializeAsync<T>(content, _options);
    }

    public async Task<List<T>> GetValueList<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);
       
        var content = await response.Content.ReadAsStreamAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception("bad request | maybe wrong address");

        return await JsonSerializer.DeserializeAsync<List<T>>(content, _options);
    }
}
//TODO: use this code for dynamic pagination
//throw new ApplicationException(GenericErrors<T.ReferenceEquals>);
// just look at "T.ReferenceEquals"