using Rubay.Sql.DataProvider.Database.Interfaces;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public abstract class SqlDataProvider<T> : ISqlDataProvider<T>
    {
        protected readonly string _sqlDataConnection;
        protected SqlDataProvider(string sqlDataConnection) =>_sqlDataConnection = sqlDataConnection;
    }
}
