using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Products
{
    public class DeleteProductResponse : ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}
