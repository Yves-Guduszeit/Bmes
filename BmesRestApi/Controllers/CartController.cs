using BmesRestApi.Messages.Requests.Carts;
using BmesRestApi.Messages.Responses.Carts;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<FetchCartResponse> GetCart()
        {
            var response = _service.FetchCart();
            return response;
        }

        [HttpPost]
        public ActionResult<AddItemToCartResponse> AddItemToCart(AddItemToCartRequest request)
        {
            var response = _service.AddItemToCart(request);
            return response;
        }

        [HttpDelete("{cartId}/{cartItemId}")]
        public ActionResult<RemoveItemFromCartResponse> RemoveItemFromCart(long cartId, long cartItemId)
        {
            var request = new RemoveItemFromCartRequest { CartId = cartId, CartItemId = cartItemId };
            var response = _service.RemoveItemFromCart(request);
            return response;
        }
    }
}
