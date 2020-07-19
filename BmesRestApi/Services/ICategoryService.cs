using BmesRestApi.Messages.Requests.Categories;
using BmesRestApi.Messages.Responses.Categories;

namespace BmesRestApi.Services
{
    public interface ICategoryService
    {
        CreateCategoryResponse SaveCategory(CreateCategoryRequest request);
        UpdateCategoryResponse EditCategory(UpdateCategoryRequest request);
        GetCategoryResponse GetCategory(GetCategoryRequest request);
        FetchCategoriesResponse GetCategories(FetchCategoriesRequest request);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);
    }
}
