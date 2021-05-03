namespace Rubay.Web.App.Models
{
    public class CheckStatusResult
    {
        public string ApiName { get; set; }
        public string ApiUrl { get; set; }
        public bool CheckResult { get; set; }

        public CheckStatusResult(string apiName, string apiUrl, bool chekResult) =>
            (ApiName, ApiUrl, CheckResult) = (apiName, apiUrl, chekResult);
    }
}
