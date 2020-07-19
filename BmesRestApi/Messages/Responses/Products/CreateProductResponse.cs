using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Products
{
    public class CreateProductResponse : ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}
