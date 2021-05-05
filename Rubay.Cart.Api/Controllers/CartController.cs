using Microsoft.AspNetCore.Mvc;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Threading.Tasks;

namespace Rubay.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository) => _cartRepository = cartRepository;

        [HttpGet("{id}")]
        public async Task<ActionResult<CartAccount>> GetAsync(string id) => await _cartRepository.GetCartAsync(id);

        [HttpPost("{productId}")]
        public async Task PostAsync(Product product, string userId) => await _cartRepository.InsertToCartAsync(product, userId);
    }
}
