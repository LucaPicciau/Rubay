using Microsoft.AspNetCore.Mvc;
using Rubay.Sql.DataProvider.Interfaces;
using System.Threading.Tasks;
using Rubay.Data.Common;
using Rubay.Data.Common.GeneralExtensions;

namespace Rubay.Cart.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository) => _cartRepository = cartRepository;

    [HttpGet("{id}")]
    public async Task<ActionResult<CartAccount>> GetAsync(string id) => await _cartRepository.GetCartAsync(id);

    [HttpPost("{userId}/insert/{product}")]
    public async Task PostAsync(string product, string userId) => await _cartRepository.InsertToCartAsync(product.ToObject<Product>(), userId);

    [HttpDelete("{userId}/delete/{productId}")]
    public async Task DeleteAsync(string productId, string userId) => await _cartRepository.DeleteFromCartAsync(productId, userId);
}