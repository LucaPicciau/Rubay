using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Data.Common.Models;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartDataProvider _cartDataProvider;
        public CartRepository(ICartDataProvider cartDataProvider) => _cartDataProvider = cartDataProvider;
        public async Task<CartAccount> GetCartAsync(string userId) => await _cartDataProvider.GetDataAsync(userId);
        public async Task InsertToCartAsync(Product product, string userId) => await _cartDataProvider.CheckInsertAsync(product, userId);
        public async Task DeleteFromCartAsync(string productId, string userId) => await _cartDataProvider.DeleteAsync(productId, userId);

    }
}
