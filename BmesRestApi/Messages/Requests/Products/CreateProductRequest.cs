using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Requests.Products
{
    public class CreateProductRequest
    {
        public ProductDto Product { get; set; }
    }
}
