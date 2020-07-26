using System.Net;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Checkouts;
using BmesRestApi.Messages.Responses.Checkouts;
using BmesRestApi.Models.Orders;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class CheckoutService : ICheckoutService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartService _cartService;

        public CheckoutService(
            ICustomerRepository customerRepository,
            IPersonRepository personRepository,
            IAddressRepository addressRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            ICartService cartService
        )
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public CheckoutResponse ProcessCheckout(CheckoutRequest request)
        {
            var response = new CheckoutResponse();
            var customer = request.Customer.MapToCustomer();

            var person = customer.Person;

            _personRepository.SavePerson(person);

            var address = request.Address.MapToAddress();

            _addressRepository.SaveAddress(address);

            customer.PersonId = person.Id;
            customer.Person = person;

            _customerRepository.SaveCustomer(customer);

            var cart = _cartService.GetCart();

            if (cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id);
                var cartTotal = _cartService.GetCartTotal();
                decimal shippingCharge = 0;
                var orderTotal = cartTotal + shippingCharge;

                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shippingCharge,
                    AddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderStatus = OrderStatus.Submitted
                };

                _orderRepository.SaveOrder(order);

                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        Quantity = cartItem.Quantity,
                        Order = order,
                        OrderId = order.Id,
                        Product = cartItem.Product,
                        ProductId = cartItem.ProductId
                    };

                    _orderItemRepository.SaveOrderItem(orderItem);
                }

                _cartRepository.DeleteCart(cart);

                response.StatusCode = HttpStatusCode.Created;
                response.Messages.Add("Order created");
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add("There is a problem creating the order");
            }

            return response;
        }
    }
}
