using BmesRestApi.Messages.DataTransferObjects.Carts;

namespace BmesRestApi.Messages.Responses.Carts
{
    public class AddItemToCartResponse : ResponseBase
    {
        public CartItemDto CartItem { get; set; }
    }
}
