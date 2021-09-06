using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rubay.Web.App.Areas.Identity.Data;
using Rubay.Web.App.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    [Authorize]
    public class CartAccountController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly IApiResponse _apiResponse;

        public CartAccountController(UserManager<AccountUser> userManager, IApiResponse apiResponse) => 
            (_userManager, _apiResponse) = (userManager, apiResponse);

        public async Task<IActionResult> Index()
        {
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var user = await _userManager.GetUserAsync(User);
            var cart = await _apiResponse.GetFromJsonAsync<CartViewResult>($"{cartApiUrl}/api/cart/{user.Id}") ?? new CartViewResult();

            cart.UserName = user.UserName;

            return View(cart);
        }

        public async Task<IActionResult> DeleteFromCart(ProductViewResult productViewResult)
        {
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");
            var user = await _userManager.GetUserAsync(User);

            await _apiResponse.GetResponseAsync($"{cartApiUrl}/api/cart/{user.Id}/delete/{productViewResult.ModelId}", HttpMethod.Delete);
            await _apiResponse.GetResponseAsync($"{itemApiUrl}/api/item/update/{productViewResult.ModelId}/{productViewResult.Quantity}", HttpMethod.Put);


            return RedirectToAction("Index");
        }
    }
}

