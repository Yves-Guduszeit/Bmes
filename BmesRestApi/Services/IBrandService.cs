using BmesRestApi.Messages.Requests.Brands;
using BmesRestApi.Messages.Responses.Brands;

namespace BmesRestApi.Services
{
    public interface IBrandService
    {
        CreateBrandResponse SaveBrand(CreateBrandRequest request);
        UpdateBrandResponse EditBrand(UpdateBrandRequest request);
        GetBrandResponse GetBrand(GetBrandRequest request);
        FetchBrandsResponse GetBrands(FetchBrandsRequest request);
        DeleteBrandResponse DeleteBrand(DeleteBrandRequest request);
    }
}
