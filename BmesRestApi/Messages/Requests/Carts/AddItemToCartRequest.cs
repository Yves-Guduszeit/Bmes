using BmesRestApi.Messages.DataTransferObjects.Carts;

namespace BmesRestApi.Messages.Requests.Carts
{
    public class AddItemToCartRequest
    {
        public long CartId { get; set; }
        public CartItemDto CartItem { get; set; }
        public long ProductId { get; set; }
    }
}
