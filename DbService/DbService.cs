using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DbService;

public sealed class DbService() : IDbService
{
    public async Task<DataTable> GetAllDataAsync(CancellationToken token = default)
    {
        return await Task.Run(() => GetData()).ConfigureAwait(false);
    }

    DataTable GetData()
    {
        DataTable dt = new();

        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));

        dt.BeginLoadData();

        try
        {
            for (int i = 0; i < 1_000; i++)
            {
                object[] values = [i, $"value-{i}"];
                dt.LoadDataRow(values, true);
            }
        }
        catch (Exception) { }
        finally { dt.EndLoadData(); }

        return dt;
    }
}
