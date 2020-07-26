using BmesRestApi.Messages.Requests.Orders;
using BmesRestApi.Messages.Responses.Orders;

namespace BmesRestApi.Services
{
    public interface IOrderService
    {
        GetOrderResponse GetOrder(GetOrderRequest request);
        FetchOrdersResponse GetOrders(FetchOrdersRequest request);
    }
}
