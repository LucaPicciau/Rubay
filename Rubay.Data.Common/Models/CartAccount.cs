using System.Collections.Generic;

namespace Rubay.Data.Common.Models
{
    public class CartAccount
    {
        public string UserId { get; set; }
        public IList<Product> Products { get; set; }
    }
}
