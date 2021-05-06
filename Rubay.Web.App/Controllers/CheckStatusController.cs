using Microsoft.AspNetCore.Mvc;
using Rubay.Web.App.Controllers;
using Rubay.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Controllers
{
    public class CheckStatusController : Controller
    {
        private readonly IApiResponse _apiResponse;

        public CheckStatusController(IApiResponse apiResponse) => _apiResponse = apiResponse;

        public async Task<IActionResult> Index()
        {
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var responseItem = await _apiResponse.GetResponseAsync($"{itemApiUrl}/api/KeepAlive", HttpMethod.Get);
            var responseCart = await _apiResponse.GetResponseAsync($"{cartApiUrl}/api/KeepAlive", HttpMethod.Get);

            var result = new List<CheckStatusResult> {
                new CheckStatusResult("ItemApi",responseItem.ResponseUri.Host, (responseItem as HttpWebResponse).StatusCode == HttpStatusCode.OK),
                new CheckStatusResult("CartApiUrl",responseCart.ResponseUri.Host,(responseCart as HttpWebResponse).StatusCode == HttpStatusCode.OK),
            };

            return View(result);
        }
    }
}
