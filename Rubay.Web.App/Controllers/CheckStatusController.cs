using Microsoft.AspNetCore.Mvc;
using Rubay.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rubay.Controllers
{
    public class CheckStatusController : Controller
    {
        private readonly ICheckApi _checkApi;

        public CheckStatusController(ICheckApi checkApi) => _checkApi = checkApi;


        public async Task<IActionResult> Index()
        {
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");
            var result = new List<CheckStatusResult> {
                new CheckStatusResult("ItemApi",itemApiUrl,await _checkApi.Check($@"{itemApiUrl}/api/KeepAlive")),
                new CheckStatusResult("CartApiUrl",cartApiUrl,await _checkApi.Check($@"{cartApiUrl}/api/KeepAlive")),
            };
            return View(result);
        }
    }
}
