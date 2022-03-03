using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Rubay.Web.App.Controllers
{
    public interface IApiResponse
    {
        public async Task<HttpResponseMessage> GetResponseAsync(string url, HttpMethod method)
        {
            try
            {
                using var client = new HttpClient();
                using var request = new HttpRequestMessage(method, new Uri(url));

                return await client.SendAsync(request);
            }
            catch(HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<HttpStatusCode> GetStatusCode(string url) =>  (await GetResponseAsync(url, HttpMethod.Get)).StatusCode;

        public async Task<T> GetFromJsonAsync<T>(string url) where T : class
        {
            try
            {
                using var client = new HttpClient();
                return await client.GetFromJsonAsync<T>(url);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}