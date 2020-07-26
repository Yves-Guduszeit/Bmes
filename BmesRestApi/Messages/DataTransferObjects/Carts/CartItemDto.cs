using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.DataTransferObjects.Carts
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
