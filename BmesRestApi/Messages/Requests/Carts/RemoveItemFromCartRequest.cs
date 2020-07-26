namespace BmesRestApi.Messages.Requests.Carts
{
    public class RemoveItemFromCartRequest
    {
        public long CartId { get; set; }
        public long CartItemId { get; set; }
    }
}
