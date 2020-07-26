using BmesRestApi.Messages.DataTransferObjects.Carts;

namespace BmesRestApi.Messages.Responses.Carts
{
    public class FetchCartResponse : ResponseBase
    {
        public CartDto Cart { get; set; }
    }
}
