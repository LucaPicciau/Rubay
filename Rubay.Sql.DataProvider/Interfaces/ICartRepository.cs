using Rubay.Sql.DataProvider.Models;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Interfaces
{
    public interface ICartRepository
    {
        public Task<CartAccount> GetCartAsync(string userId);
        public Task InsertToCartAsync(Product product, string userId);
        public Task DeleteFromCartAsync(string productId, string userId);
    }
}
