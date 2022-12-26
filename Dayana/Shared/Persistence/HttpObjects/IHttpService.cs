using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.HttpObjects;
public interface IHttpService
{
    Task<List<T>> GetValueList<T>(string requestUrl);
    Task<T> GetValue<T>(string requestUrl);
}
