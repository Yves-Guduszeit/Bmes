using System.Collections.Generic;
using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Brands
{
    public class FetchBrandsResponse : ResponseBase
    {
        public int BrandsPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<BrandDto> Brands { get; set; }
    }
}
