namespace Rubay.Web.App.Models;

public record ErrorViewModel(string RequestId)
{
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}