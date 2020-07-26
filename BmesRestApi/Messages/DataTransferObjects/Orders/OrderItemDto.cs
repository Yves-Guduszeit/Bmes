using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.DataTransferObjects.Orders
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
