using Rubay.Data.Common;

namespace Rubay.Sql.DataProvider.Interfaces;

public interface IProductDataProvider
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product> GetDataAsync(string id);
    public Task UpdateAsync(string productId, int quantity);
}