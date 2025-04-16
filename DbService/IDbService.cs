using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DbService;

public interface IDbService
{
    Task<DataTable> GetAllDataAsync(CancellationToken token = default);
}
