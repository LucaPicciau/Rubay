using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductRepository(IProductDataProvider productDataProvider) =>
            _productDataProvider = productDataProvider;

        public Product GetProduct(string productId) => _productDataProvider.GetData(productId);
        public IEnumerable<Product> GetProducts() => _productDataProvider.GetAll();
    }
}
