using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Brands
{
    public class DeleteBrandResponse : ResponseBase
    {
        public BrandDto Brand { get; set; }
    }
}
