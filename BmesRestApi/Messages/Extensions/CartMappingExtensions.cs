using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.DataTransferObjects.Carts;
using BmesRestApi.Models.Carts;

namespace BmesRestApi.Messages.Extensions
{
    public static class CartMappingExtensions
    {
        public static Cart MapToCart(this CartDto cartDto)
        {
            var cart = new Cart
            {
                Id = cartDto.Id,
                UniqueCartId = cartDto.UniqueCartId,
                CartStatus = (CartStatus) cartDto.CartStatus,
                CreatedDate = cartDto.CreatedDate,
                ModifiedDate = cartDto.ModifiedDate,
                IsDeleted = cartDto.IsDeleted
            };

            return cart;
        }

        public static CartDto MapToCartDto(this Cart cart)
        {
            var cartDto = new CartDto
            {
                Id = cart.Id,
                UniqueCartId = cart.UniqueCartId,
                CartStatus = (int) cart.CartStatus,
                CreatedDate = cart.CreatedDate,
                ModifiedDate = cart.ModifiedDate,
                IsDeleted = cart.IsDeleted
            };

            return cartDto;
        }

        public static CartItem MapToCartItem(this CartItemDto cartItemDto)
        {
            var cartItem = new CartItem
            {
                CartId = cartItemDto.CartId,
                ProductId = cartItemDto.Product.Id,
                Quantity = cartItemDto.Quantity
            };

            return cartItem;
        }

        public static CartItemDto MapToCartItemDto(this CartItem cartItem)
        {
            var productDto = cartItem.Product.MapToProductDto();
            var cartItemDto = new CartItemDto
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                Product = productDto,
                Quantity = cartItem.Quantity
            };

            return cartItemDto;
        }

        public static List<CartItemDto> MapToCartItemDtos(this IEnumerable<CartItem> cartItems)
        {
            var cartItemDtos = cartItems.Select(MapToCartItemDto).ToList();

            return cartItemDtos;
        }
    }
}
