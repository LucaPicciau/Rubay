using Rubay.Data.Common.Models;

namespace Rubay.Web.App.Models
{
    public class ProductViewResult
    {
        public string ModelId { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public ProductViewResult()
        {}

        public Product ToProduct() => new() { ModelId = ModelId, Description = Description, ModelName = ModelName, Quantity = Quantity };
    }
}
