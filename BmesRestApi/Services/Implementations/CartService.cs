using System;
using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Carts;
using BmesRestApi.Messages.Responses.Carts;
using BmesRestApi.Models.Carts;
using BmesRestApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace BmesRestApi.Services.Implementations
{
    public class CartService : ServiceBase, ICartService
    {
        private const string UniqueCartIdSessionKey = "UniqueCartId";

        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly HttpContext _httpContext;

        public CartService(
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public AddItemToCartResponse AddItemToCart(AddItemToCartRequest addItemToCartRequest)
        {
            var response = new AddItemToCartResponse();

            var cart = GetCart();
            if (cart != null)
            {
                var existingCartItem = _cartItemRepository.FindCartItemsByCartId(cart.Id)
                    .FirstOrDefault(c => c.ProductId == addItemToCartRequest.ProductId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _cartItemRepository.UpdateCartItem(existingCartItem);

                    response.CartItem = existingCartItem.MapToCartItemDto();
                }
                else
                {
                    var product = _productRepository.FindProductById(addItemToCartRequest.ProductId);
                    if (product != null)
                    {
                        var cartItem = new CartItem
                        {
                            CartId = cart.Id,
                            Cart = cart,
                            ProductId = addItemToCartRequest.ProductId,
                            Product = product,
                            Quantity = 1
                        };
                        _cartItemRepository.SaveCartItem(cartItem);
                        response.CartItem = cartItem.MapToCartItemDto();
                    }
                }
            }
            else
            {
                var product = _productRepository.FindProductById(addItemToCartRequest.ProductId);
                if (product != null)
                {
                    var newCart = new Cart
                    {
                        UniqueCartId = UniqueCartId(),
                        CartStatus = CartStatus.Open
                    };

                    _cartRepository.SaveCart(newCart);

                    var cartItem = new CartItem
                    {
                        CartId = newCart.Id,
                        Cart = newCart,
                        ProductId = addItemToCartRequest.ProductId,
                        Product = product,
                        Quantity = 1
                    };

                    _cartItemRepository.SaveCartItem(cartItem);

                    response.CartItem = cartItem.MapToCartItemDto();

                }
            }
            return response;
        }

        public RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest)
        {
            var response = new RemoveItemFromCartResponse();
            var cartItem = _cartItemRepository.FindCartItemById(removeItemFromCartRequest.CartItemId);
            _cartItemRepository.DeleteCartItem(cartItem);

            response.CartItemId = cartItem.Id;
            return response;
        }

        private string UniqueCartId()
        {
            if (string.IsNullOrWhiteSpace(_httpContext.Session.GetString(UniqueCartIdSessionKey)))
            {
                var uniqueId = Guid.NewGuid().ToString();
                _httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);
            }

            return _httpContext.Session.GetString(UniqueCartIdSessionKey);
        }

        public Cart GetCart()
        {
            var uniqueId = UniqueCartId();
            var cart = _cartRepository.GetAllCarts().FirstOrDefault(c => c.UniqueCartId == uniqueId);

            return cart;
        }

        public FetchCartResponse FetchCart()
        {
            var response = new FetchCartResponse();
            var cart = GetCart();

            if (cart != null)
            {
                IList<CartItem> cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id).ToArray();
                var cartItemsDto = cartItems.MapToCartItemDtos();
                var cartDto = cart.MapToCartDto();
                cartDto.CartItems = cartItemsDto;
                response.Cart = cartDto;
            }

            return response;
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            IList<CartItem> cartItems = new List<CartItem>();

            var cart = GetCart();
            if (cart != null)
            {
                cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id).ToArray();
            }

            return cartItems;
        }

        public int CartItemsCount()
        {
            var cartItems = GetCartItems();

            return cartItems.Sum(cartItem => cartItem.Quantity);
        }

        public decimal GetCartTotal()
        {
            decimal total = 0;

            var cartItems = GetCartItems();

            foreach (var cartItem in cartItems)
            {
                var product = _productRepository.FindProductById(cartItem.ProductId);
                total += cartItem.Quantity * product.Price;
            }

            return total;
        }
    }
}
