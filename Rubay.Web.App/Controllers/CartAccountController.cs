using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    public class CartAccountController : Controller
    {
        public IActionResult Index()
        {
            var cartApiUrl = Environment.GetEnvironmentVariable("CartApiUrl");

            var p = $@"http://localhost:5656/api/Cart/0ab8a68c-d8cb-4f21-b27f-8e08f4686a44";

            var request = HttpWebRequest.Create(p);
            var response = request.GetResponse();
            var x = JsonConvert.DeserializeObject<CartView>(response.ContentType, new JsonSerializerSettings() { Formatting = Formatting.Indented });
            return View(x);
        }
    }


    public class APIResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T ReturnObject { get; set; }
    }

    public class ProductView
    {
        [JsonPropertyName("modelId")]
        public string ModelId { get; set; }

        [JsonPropertyName("modelName")]
        public string ModelName { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class CartView
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("products")]
        public List<ProductView> Products { get; set; }
    }
}
