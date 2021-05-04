using Microsoft.AspNetCore.Mvc;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;

namespace Rubay.Item.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ItemController(IProductRepository productRepository) => _productRepository = productRepository;

        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id) => _productRepository.GetProduct(id);

        [HttpGet]
        public IEnumerable<Product> GetAll() => _productRepository.GetProducts();
    }
}
