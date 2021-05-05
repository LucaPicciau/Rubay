using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rubay.Web.App.Areas.Identity.Data;
using Rubay.Web.App.Models;
using System;
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
            var cart = await _apiResponse.ReturnObjectFromJsonAsync<CartViewResult>($"{cartApiUrl}/api/cart/{user.Id}") ?? new CartViewResult();

            cart.UserName = user.UserName;

            return View(cart);
        }
    }
}

