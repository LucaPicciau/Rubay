using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    public interface IApiResponse
    {
        public async Task<WebResponse> GetWebResponse(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                return await request.GetResponseAsync();
            }
            catch(WebException ex)
            {
                return ex.Response;
            }
        }

        public async Task<HttpStatusCode> GetStatusCode(string url) =>  (await GetWebResponse(url) as HttpWebResponse).StatusCode;

        public async Task<T> ReturnObjectFromJsonAsync<T>(string url) where T : class
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}