using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.HttpObjects;
public interface IHttpService
{
    Task<List<T>> GetValueList<T>(string requestUrl);
    Task<T> GetValue<T>(string requestUrl);
    Task<HttpResponseMessage> PostValue<T>(string requestUrl, T data);
    Task<HttpResponseMessage> PutValue<T>(string requestUrl, T data);
    Task<HttpResponseMessage> PatchValue<T>(string requestUrl, T data);
    Task<HttpResponseMessage> DeleteValue<T>(string requestUrl);
    Task<PaginatedList<T>> GetPagedValue<T>(string requestUrl);
}
