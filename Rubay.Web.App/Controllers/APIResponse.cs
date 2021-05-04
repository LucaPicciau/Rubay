using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
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
}

