namespace BmesRestApi.Messages.Requests.Brands
{
    public class FetchBrandsRequest
    {
        public int PageNumber { get; set; }
        public int BrandsPerPage { get; set; }
    }
}
