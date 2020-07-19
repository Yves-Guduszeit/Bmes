using System.Net;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Categories;
using BmesRestApi.Messages.Responses.Categories;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CreateCategoryResponse SaveCategory(CreateCategoryRequest request)
        {
            var response = new CreateCategoryResponse();

            WithErrorHandling(() =>
            {
                var category = request.Category.MapToCategory();
                _categoryRepository.SaveCategory(category);

                var categoryDto = category.MapToCategoryDto();
                response.Category = categoryDto;
                response.Messages.Add("Successfully saved the category");
                response.StatusCode = HttpStatusCode.Created;
            }, response);

            return response;
        }

        public UpdateCategoryResponse EditCategory(UpdateCategoryRequest request)
        {
            var response = new UpdateCategoryResponse();

            WithErrorHandling(() =>
            {
                var category = request.Category.MapToCategory();
                _categoryRepository.UpdateCategory(category);

                response.Messages.Add("Successfully updated the category");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest request)
        {
            var response = new GetCategoryResponse();

            WithErrorHandling(() =>
            {
                var category = _categoryRepository.FindCategoryById(request.Id);

                var categoryDto = category.MapToCategoryDto();
                response.Category = categoryDto;
                response.Messages.Add("Successfully get the category");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public FetchCategoriesResponse GetCategories(FetchCategoriesRequest request)
        {
            var response = new FetchCategoriesResponse();

            WithErrorHandling(() =>
            {
                var categories = _categoryRepository.GetAllCategories();

                var categoryDtos = categories.MapToCategoryDtos();
                response.Categories = categoryDtos;
                response.Messages.Add("Successfully fetched the categories");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request)
        {
            var response = new DeleteCategoryResponse();

            WithErrorHandling(() =>
            {
                var category = _categoryRepository.FindCategoryById(request.Id);
                _categoryRepository.DeleteCategory(category);

                var categoryDto = category.MapToCategoryDto();
                response.Category = categoryDto;
                response.Messages.Add("Successfully deleted the category");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }
    }
}
