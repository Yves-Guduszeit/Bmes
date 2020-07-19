using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Products
{
    public class GetProductResponse : ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}
