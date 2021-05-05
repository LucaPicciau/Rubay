using Rubay.Sql.DataProvider.Models;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface ICartDataProvider : ISqlFind<CartAccount, string>
    {
        public Task InsertAsync(Product product, string userId);
        public Task DeleteAsync(string productId, string userId);
    }
}
