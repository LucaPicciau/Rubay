using Rubay.Sql.DataProvider.Models;

namespace Rubay.Sql.DataProvider.Interfaces
{
    public interface ICartRepository
    {
        public CartAccount GetCart(string userId);
    }
}
