using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    public interface IApiResponse
    {
        public async Task<WebResponse> GetResponseAsync(string url, HttpMethod method)
        {
            try
            {
                var client = WebRequest.Create(url);
                client.Method = method.Method;
                return await client.GetResponseAsync();
            }
            catch(WebException ex)
            {
                return ex.Response;
            }
        }

        public async Task<HttpStatusCode> GetStatusCode(string url) =>  (await GetResponseAsync(url, HttpMethod.Get) as HttpWebResponse).StatusCode;

        public async Task<T> GetFromJsonAsync<T>(string url) where T : class
        {
            try
            {
                using var client = new HttpClient();
                return await client.GetFromJsonAsync<T>(url);
            }
            catch
            {
                return null;
            }
        }
    }
}