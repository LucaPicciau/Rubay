using System.Net;
using System.Threading.Tasks;

namespace Rubay.Web.App.Models
{
    public interface ICheckApi
    {
        public async Task<bool> Check(string url)
        {
            var request = HttpWebRequest.Create(url);
            try
            {
                var response = await request.GetResponseAsync();
                return (response as HttpWebResponse).StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
