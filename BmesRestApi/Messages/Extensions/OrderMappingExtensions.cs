using BmesRestApi.Messages.DataTransferObjects.Orders;
using BmesRestApi.Models.Orders;

namespace BmesRestApi.Messages.Extensions
{
    public static class OrderMappingExtensions
    {
        public static Order MapToOrder(this OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                OrderTotal = orderDto.OrderTotal,
                OrderItemTotal = orderDto.OrderTotal,
                ShippingCharge = orderDto.ShippingCharge,
                CustomerId = orderDto.CustomerId,
                OrderStatus = (OrderStatus) orderDto.OrderStatus,
                CreatedDate = orderDto.CreatedDate,
                ModifiedDate = orderDto.ModifiedDate,
                IsDeleted = orderDto.IsDeleted
            };

            return order;
        }

        public static OrderDto MapToOrderDto(this Order order)
        {
            var orderDto = new OrderDto
            {
                Id = order.Id,
                OrderTotal = order.OrderTotal,
                OrderItemTotal = order.OrderTotal,
                ShippingCharge = order.ShippingCharge,
                CustomerId = order.CustomerId,
                OrderStatus = (int) order.OrderStatus,
                CreatedDate = order.CreatedDate,
                ModifiedDate = order.ModifiedDate,
                IsDeleted = order.IsDeleted
            };

            return orderDto;
        }

        public static OrderItem MapToOrderItem(this OrderItemDto orderItemDto)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.Product.Id,
                Quantity = orderItemDto.Quantity
            };

            return orderItem;
        }

        public static OrderItemDto MapToOrderItemDto(this OrderItem orderItem)
        {
            OrderItemDto orderItemDto = null;

            if (orderItem?.Product != null)
            {
                var productDto = orderItem.Product.MapToProductDto();

                orderItemDto = new OrderItemDto
                {
                    Id = orderItem.Id,
                    OrderId = orderItem.OrderId,
                    Product = productDto,
                    Quantity = orderItem.Quantity
                };
            }

            return orderItemDto;
        }
    }
}
