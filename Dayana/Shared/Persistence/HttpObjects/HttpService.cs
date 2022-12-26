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

    public Task<T> GetValue<T>()
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetValueList<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var dataList = JsonSerializer.Deserialize<List<T>>(content, _options);
        return dataList;
    }
}
