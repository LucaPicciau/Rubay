using Rubay.Data.Common;

namespace Rubay.Sql.DataProvider.Interfaces;

public interface ICartDataProvider
{
    public Task<CartAccount> GetDataAsync(string id);
    public Task CheckInsertAsync(Product product, string userId);
    public Task UpdateAsync(Product product, string userId);
    public Task InsertAsync(Product product, string userId);
    public Task DeleteAsync(string productId, string userId);
}