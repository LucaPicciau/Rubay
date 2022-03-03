using Rubay.Sql.DataProvider.Database.Interfaces;

namespace Rubay.Sql.DataProvider.Database.Providers
{
    public abstract class SqlDataProvider<T> : ISqlDataProvider<T>
    {
        protected readonly string SqlDataConnection;
        protected SqlDataProvider(string sqlDataConnection) => SqlDataConnection = sqlDataConnection;
    }
}
