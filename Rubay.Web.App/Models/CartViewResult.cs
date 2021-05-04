using System.Collections.Generic;

namespace Rubay.Web.App.Models
{
    public class CartViewResult
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<ProductViewResult> Products { get; set; }

        public CartViewResult()
        {
            Products = new List<ProductViewResult>();
        }
    }
}
