using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface IProductDataProvider : ISqlGetAll<Product>, ISqlFind<Product, string>
    {
    }
}
