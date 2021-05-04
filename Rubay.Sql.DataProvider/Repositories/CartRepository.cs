using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartSqlDataProvider _cartSqlDataProvider;

        public CartRepository(ICartSqlDataProvider cartSqlDataProvider) =>
            _cartSqlDataProvider = cartSqlDataProvider;

        public Cart GetCart(string userId) => _cartSqlDataProvider.GetData(userId);
    }
}
