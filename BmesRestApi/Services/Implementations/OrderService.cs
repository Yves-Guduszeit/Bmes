using BmesRestApi.Messages.Requests.Orders;
using BmesRestApi.Messages.Responses.Orders;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            return new GetOrderResponse();
        }

        public FetchOrdersResponse GetOrders(FetchOrdersRequest request)
        {
            return new FetchOrdersResponse();
        }
    }
}
