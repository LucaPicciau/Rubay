using Rubay.Data.Common;

namespace Rubay.Sql.DataProvider.Interfaces;

public interface IProductRepository
{
    public Task<Product> GetProductAsync(string productId);
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task UpdateProductAsync(string productId, int quantity);
}