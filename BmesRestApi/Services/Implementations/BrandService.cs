using System.Net;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Brands;
using BmesRestApi.Messages.Responses.Brands;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class BrandService : ServiceBase, IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public CreateBrandResponse SaveBrand(CreateBrandRequest request)
        {
            var response = new CreateBrandResponse();

            WithErrorHandling(() =>
            {
                var brand = request.Brand.MapToBrand();
                _brandRepository.SaveBrand(brand);

                var brandDto = brand.MapToBrandDto();
                response.Brand = brandDto;
                response.Messages.Add("Successfully saved the brand");
                response.StatusCode = HttpStatusCode.Created;
            }, response);

            return response;
        }

        public UpdateBrandResponse EditBrand(UpdateBrandRequest request)
        {
            var response = new UpdateBrandResponse();

            WithErrorHandling(() =>
            {
                var brand = request.Brand.MapToBrand();
                _brandRepository.UpdateBrand(brand);

                response.Messages.Add("Successfully updated the brand");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public GetBrandResponse GetBrand(GetBrandRequest request)
        {
            var response = new GetBrandResponse();

            WithErrorHandling(() =>
            {
                var brand = _brandRepository.FindBrandById(request.Id);

                var brandDto = brand.MapToBrandDto();
                response.Brand = brandDto;
                response.Messages.Add("Successfully get the brand");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public FetchBrandsResponse GetBrands(FetchBrandsRequest request)
        {
            var response = new FetchBrandsResponse();

            WithErrorHandling(() =>
            {
                var brands = _brandRepository.GetAllBrands();

                var brandDtos = brands.MapToBrandDtos();
                response.Brands = brandDtos;
                response.Messages.Add("Successfully fetched the brands");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public DeleteBrandResponse DeleteBrand(DeleteBrandRequest request)
        {
            var response = new DeleteBrandResponse();

            WithErrorHandling(() =>
            {
                var brand = _brandRepository.FindBrandById(request.Id);
                _brandRepository.DeleteBrand(brand);

                var brandDto = brand.MapToBrandDto();
                response.Brand = brandDto;
                response.Messages.Add("Successfully deleted the brand");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }
    }
}
