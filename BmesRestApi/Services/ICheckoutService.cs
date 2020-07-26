using BmesRestApi.Messages.Requests.Checkouts;
using BmesRestApi.Messages.Responses.Checkouts;

namespace BmesRestApi.Services
{
    public interface ICheckoutService
    {
        CheckoutResponse ProcessCheckout(CheckoutRequest request);
    }
}
