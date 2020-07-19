using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Brands
{
    public class GetBrandResponse : ResponseBase
    {
        public BrandDto Brand { get; set; }
    }
}
