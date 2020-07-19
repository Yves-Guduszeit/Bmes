using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Categories
{
    public class CreateCategoryResponse : ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}
