using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Models
{
    public class CartAccount
    {
        public string UserId { get; set; }
        public IList<Product> Products { get; set; }
    }
}
