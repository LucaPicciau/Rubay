using Microsoft.AspNetCore.Mvc;
using Rubay.Data.Common;
using Rubay.Sql.DataProvider.Interfaces;

namespace Rubay.Item.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ItemController(IProductRepository productRepository) => _productRepository = productRepository;

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(string id) => await _productRepository.GetProductAsync(id);

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllAsync() => await _productRepository.GetProductsAsync();

    [HttpPut("update/{productId}/{quantity}")]
    public async Task Update(string productId, int quantity) => await _productRepository.UpdateProductAsync(productId, quantity);
}