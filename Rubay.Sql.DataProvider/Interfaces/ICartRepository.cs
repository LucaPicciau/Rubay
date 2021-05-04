using Rubay.Sql.DataProvider.Models;

namespace Rubay.Sql.DataProvider.Interfaces
{
    public interface ICartRepository
    {
        public Cart GetCart(string userId);
    }
}
