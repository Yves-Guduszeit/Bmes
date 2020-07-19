using BmesRestApi.Messages.Requests.Categories;
using BmesRestApi.Messages.Responses.Categories;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GetCategoryResponse> GetCategory(long id)
        {
            var request = new GetCategoryRequest { Id = id };
            var response = _service.GetCategory(request);
            return response;
        }

        [HttpGet]
        public ActionResult<FetchCategoriesResponse> GetCategories()
        {
            var request = new FetchCategoriesRequest();
            var response = _service.GetCategories(request);
            return response;
        }

        [HttpPost]
        public ActionResult<CreateCategoryResponse> PostCategory(CreateCategoryRequest request)
        {
            var response = _service.SaveCategory(request);
            return response;
        }

        [HttpPut]
        public ActionResult<UpdateCategoryResponse> PutCategory(UpdateCategoryRequest request)
        {

            var response = _service.EditCategory(request);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteCategoryResponse> DeleteCategory(long id)
        {
            var request = new DeleteCategoryRequest { Id = id };
            var response = _service.DeleteCategory(request);
            return response;
        }
    }
}
