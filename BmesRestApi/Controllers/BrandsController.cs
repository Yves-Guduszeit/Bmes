using BmesRestApi.Messages.Requests.Brands;
using BmesRestApi.Messages.Responses.Brands;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GetBrandResponse> GetBrand(long id)
        {
            var request = new GetBrandRequest { Id = id };
            var response = _service.GetBrand(request);
            return response;
        }

        [HttpGet]
        public ActionResult<FetchBrandsResponse> GetBrands()
        {
            var request = new FetchBrandsRequest();
            var response = _service.GetBrands(request);
            return response;
        }

        [HttpPost]
        public ActionResult<CreateBrandResponse> PostBrand(CreateBrandRequest request)
        {
            var response = _service.SaveBrand(request);
            return response;
        }

        [HttpPut]
        public ActionResult<UpdateBrandResponse> PutBrand(UpdateBrandRequest request)
        {
            var response = _service.EditBrand(request);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteBrandResponse> DeleteBrand(long id)
        {
            var request = new DeleteBrandRequest { Id = id };
            var response = _service.DeleteBrand(request);
            return response;
        }
    }
}
