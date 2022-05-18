using System.Data.SqlClient;
using Dapper;

namespace Rubay.Sql.DataProvider.Database;

public abstract class SqlDataProvider
{
    private readonly string _sqlDataConnection;
    protected SqlDataProvider(string sqlDataConnection) => _sqlDataConnection = sqlDataConnection;

    protected async Task<IEnumerable<T>> ExecuteAsync<T>(string query, object input = null)
    {
        await using SqlConnection conn = new(_sqlDataConnection);
        return await conn.QueryAsync<T>(query, input);
    }

    protected async Task ExecuteAsync(string query, object input = null)
    {
        await using SqlConnection conn = new(_sqlDataConnection);
        await conn.QueryAsync(query, input);
    }
}