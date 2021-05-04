using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductSqlDataProvider _productSqlDataProvider;

        public ProductRepository(IProductSqlDataProvider productSqlDataProvider) =>
            _productSqlDataProvider = productSqlDataProvider;

        public Product GetProduct(string productId) => _productSqlDataProvider.GetData(productId);
        public IEnumerable<Product> GetProducts() => _productSqlDataProvider.GetAll();
    }
}
