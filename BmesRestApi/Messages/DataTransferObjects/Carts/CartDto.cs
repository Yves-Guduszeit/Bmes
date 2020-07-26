using System;
using System.Collections.Generic;

namespace BmesRestApi.Messages.DataTransferObjects.Carts
{
    public class CartDto
    {
        public CartDto()
        {
            CartItems = new List<CartItemDto>();
        }

        public long Id { get; set; }
        public string UniqueCartId { get; set; }
        public int CartStatus { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}
