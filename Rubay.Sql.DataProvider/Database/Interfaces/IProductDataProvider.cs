using Rubay.Data.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface IProductDataProvider
    {
        public IAsyncEnumerable<Product> GetAllAsync();
        public Task<Product> GetDataAsync(string id);
        public Task UpdateAsync(string productId, int quantity);
    }
}
