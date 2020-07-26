using BmesRestApi.Messages.Requests.Brands;
using BmesRestApi.Messages.Responses.Brands;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<GetBrandResponse> GetBrand(long id)
        {
            var request = new GetBrandRequest { Id = id };
            var response = _service.GetBrand(request);
            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<FetchBrandsResponse> GetBrands()
        {
            var request = new FetchBrandsRequest();
            var response = _service.GetBrands(request);
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<CreateBrandResponse> PostBrand(CreateBrandRequest request)
        {
            var response = _service.SaveBrand(request);
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public ActionResult<UpdateBrandResponse> PutBrand(UpdateBrandRequest request)
        {
            var response = _service.EditBrand(request);
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<DeleteBrandResponse> DeleteBrand(long id)
        {
            var request = new DeleteBrandRequest { Id = id };
            var response = _service.DeleteBrand(request);
            return response;
        }
    }
}
