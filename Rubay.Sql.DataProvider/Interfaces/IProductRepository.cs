using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Interfaces
{
    public interface IProductRepository
    {
        public Product GetProduct(string productId);
        public IEnumerable<Product> GetProducts();
    }
}
