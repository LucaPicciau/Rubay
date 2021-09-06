using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Data.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDataProvider _productDataProvider;
        public ProductRepository(IProductDataProvider productDataProvider) => _productDataProvider = productDataProvider;
        public IEnumerable<Product> GetProductsAsync() => _productDataProvider.GetAllAsync().ToEnumerable();
        public async Task<Product> GetProductAsync(string productId) => await _productDataProvider.GetDataAsync(productId);
        public async Task UpdateProductAsync(string productId, int quantity) => await _productDataProvider.UpdateAsync(productId, quantity);
    }
}
