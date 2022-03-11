using System.Data.SqlClient;
using Dapper;
using Rubay.Sql.DataProvider.Interfaces;

namespace Rubay.Sql.DataProvider.Database;

public abstract class SqlDataProvider<T> : ISqlDataProvider<T>
{
    protected readonly string SqlDataConnection;
    protected SqlDataProvider(string sqlDataConnection) => SqlDataConnection = sqlDataConnection;

    protected async Task<IEnumerable<TOutput>> ExecuteAsync<TOutput>(string connString, object input = null)
    {
        await using SqlConnection conn = new(SqlDataConnection);
        return await conn.QueryAsync<TOutput>(connString, input);
    }

    protected async Task ExecuteAsync(string connString, object input = null)
    {
        await using SqlConnection conn = new(SqlDataConnection);
        await conn.QueryAsync(connString, input);
    }
}