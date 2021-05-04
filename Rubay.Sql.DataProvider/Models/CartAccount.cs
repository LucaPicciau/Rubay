using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Models
{
    public class CartAccount
    {
        public string UserId { get; set; }
        public IList<Product> Products { get; set; }
    }
}
