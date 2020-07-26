using BmesRestApi.Messages.DataTransferObjects.Orders;

namespace BmesRestApi.Messages.Responses.Orders
{
    public class GetOrderResponse : ResponseBase
    {
        public OrderDto Order { get; set; }
    }
}
