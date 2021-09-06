using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rubay.Data.Common.GeneralExtensions;
using Rubay.Web.App.Areas.Identity.Data;
using Rubay.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly IApiResponse _apiResponse;

        public ProductController(UserManager<AccountUser> userManager, IApiResponse apiResponse) => 
            (_userManager, _apiResponse) = (userManager, apiResponse);

        public async Task<IActionResult> Index()
        {
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");
            var products = await _apiResponse.GetFromJsonAsync<IEnumerable<ProductViewResult>>($"{itemApiUrl}/api/item");

            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> InsertToCart(ProductViewResult productViewResult)
        {
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");

            var user = await _userManager.GetUserAsync(User);

            productViewResult.Quantity = 1;

            await _apiResponse.GetResponseAsync($"{cartApiUrl}/api/cart/{user.Id}/insert/{productViewResult.ToJson()}", HttpMethod.Post);
            await _apiResponse.GetResponseAsync($"{itemApiUrl}/api/item/update/{productViewResult.ModelId}/{-productViewResult.Quantity}", HttpMethod.Put);

            return RedirectToAction("Index");
        }
    }
}
