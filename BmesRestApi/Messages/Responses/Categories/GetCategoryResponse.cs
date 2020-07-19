using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Categories
{
    public class GetCategoryResponse : ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}
