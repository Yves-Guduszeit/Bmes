using BmesRestApi.Messages.DataTransferObjects.Addresses;
using BmesRestApi.Messages.DataTransferObjects.Carts;
using BmesRestApi.Messages.DataTransferObjects.Customers;

namespace BmesRestApi.Messages.Requests.Checkouts
{
    public class CheckoutRequest
    {
        public CustomerDto Customer { get; set; }

        public AddressDto Address { get; set; }

        public CartDto Cart { get; set; }
    }
}
