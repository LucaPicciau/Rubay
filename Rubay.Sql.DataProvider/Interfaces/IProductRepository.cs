using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(string productId);
        public IEnumerable<Product> GetProducts();
    }
}
