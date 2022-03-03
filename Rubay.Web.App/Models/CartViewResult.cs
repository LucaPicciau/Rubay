using System.Collections.Generic;

namespace Rubay.Web.App.Models
{
    public record CartViewResult(string UserName, IList<ProductViewResult> Products);
}
