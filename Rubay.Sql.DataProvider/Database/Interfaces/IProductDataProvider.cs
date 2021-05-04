using Rubay.Sql.DataProvider.Models;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface IProductDataProvider : ISqlGetAll<Product>, ISqlFind<Product, string>
    {
    }
}
