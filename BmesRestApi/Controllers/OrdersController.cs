using BmesRestApi.Messages.Requests.Orders;
using BmesRestApi.Messages.Responses.Orders;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GetOrderResponse> GetOrder(long id)
        {
            var request = new GetOrderRequest { Id = id };
            var response = _service.GetOrder(request);
            return response;
        }

        [HttpGet]
        public ActionResult<FetchOrdersResponse> GetOrders()
        {
            var request = new FetchOrdersRequest();
            var response = _service.GetOrders(request);
            return response;
        }
    }
}
