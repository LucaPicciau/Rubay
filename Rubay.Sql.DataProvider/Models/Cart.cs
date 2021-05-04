using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Models
{
    public class Cart
    {
        public string UserId { get; set; }
        public IList<Product> Products { get; set; }
        public int Quantity { get; set; }
    }
}
