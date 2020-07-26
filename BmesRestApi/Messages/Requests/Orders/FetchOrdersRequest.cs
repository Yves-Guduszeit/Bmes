namespace BmesRestApi.Messages.Requests.Orders
{
    public class FetchOrdersRequest
    {
        public int PageNumber { get; set; }
        public int OrdersPerPage { get; set; }
    }
}
