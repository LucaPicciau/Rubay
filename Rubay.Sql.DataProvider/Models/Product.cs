using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Models
{
    public class Product
    {
        public string ModelId { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
