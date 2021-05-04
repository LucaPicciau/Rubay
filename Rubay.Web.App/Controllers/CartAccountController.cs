using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubay.Web.App.Areas.Identity.Data;
using Rubay.Web.App.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    [Authorize]
    public class CartAccountController : Controller
    {
        private readonly UserManager<AccountUser> _userManager;

        public CartAccountController(UserManager<AccountUser> userManager) => _userManager = userManager;

        public async Task<IActionResult> Index()
        {
            var currentUser = this.User;
            var user = await _userManager.GetUserAsync(currentUser);

            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var response = new APIResponse<CartViewResult>($@"{cartApiUrl}/api/Cart/{user.Id}");
            var cart = await response.ReturnObjectFromJsonAsync() ?? new CartViewResult();

            cart.UserName = user.UserName;

            return View(cart);
        }
    }
}


public class APIResponse<T> where T : class
{
    public HttpStatusCode StatusCode { get; set; }
    public string Url { get; set; }

    public APIResponse(string apiUrl) => Url = apiUrl;

    public async Task<T> ReturnObjectFromJsonAsync()
    {
        var client = new HttpClient();

        var response = await client.GetAsync(Url);

        StatusCode = response.StatusCode;

        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }
}
