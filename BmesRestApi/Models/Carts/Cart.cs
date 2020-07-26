using System.Collections.Generic;
using BmesRestApi.Models.Shared;

namespace BmesRestApi.Models.Carts
{
    public class Cart : BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public string UniqueCartId { get; set; }
        public CartStatus CartStatus { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
