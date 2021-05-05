﻿using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductRepository(IProductDataProvider productDataProvider) =>
            _productDataProvider = productDataProvider;

        public async Task<Product> GetProduct(string productId) => await _productDataProvider.GetDataAsync(productId);
        public IEnumerable<Product> GetProducts() => _productDataProvider.GetAll();
    }
}
