using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rubay.Web.App.Models;

namespace Rubay.Web.App.Pages
{
    public class CheckStatusModel : PageModel
    {
        private readonly ILogger<CheckStatusModel> _logger;
        private readonly ICheckApi _checkApi;

        public IEnumerable<CheckStatusResult> Results { get; private set; }

        public CheckStatusModel(ILogger<CheckStatusModel> logger, ICheckApi checkApi) => (_logger, _checkApi) = (logger, checkApi);

        public async Task OnGet()
        {
            var itemApiUrl = Environment.GetEnvironmentVariable("ItemApiUrl");
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");

            Results = new List<CheckStatusResult> {
                new CheckStatusResult("ItemApiUrl",itemApiUrl,await _checkApi.Check($@"{itemApiUrl}/api/keepalive")),
                new CheckStatusResult("CartApiUrl",cartApiUrl,await _checkApi.Check($@"{cartApiUrl}/api/keepalive")),
            };
        }
    }
}
