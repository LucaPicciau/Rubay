using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartDataProvider _cartDataProvider;

        public CartRepository(ICartDataProvider cartDataProvider) =>
            _cartDataProvider = cartDataProvider;

        public Cart GetCart(string userId) => _cartDataProvider.GetData(userId);
    }
}
