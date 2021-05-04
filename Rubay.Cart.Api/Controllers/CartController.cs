using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<CartAccount> Get(string id) => _cartRepository.GetCart(id);
    }
}
