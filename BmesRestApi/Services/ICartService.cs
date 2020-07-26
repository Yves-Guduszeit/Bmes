using System.Collections.Generic;
using BmesRestApi.Messages.Requests.Carts;
using BmesRestApi.Messages.Responses.Carts;
using BmesRestApi.Models.Carts;

namespace BmesRestApi.Services
{
    public interface ICartService
    {
        AddItemToCartResponse AddItemToCart(AddItemToCartRequest addItemToCartRequest);
        RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest);
        Cart GetCart();
        FetchCartResponse FetchCart();
        IEnumerable<CartItem> GetCartItems();
        int CartItemsCount();
        decimal GetCartTotal();
    }
}
