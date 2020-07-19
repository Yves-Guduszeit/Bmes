using BmesRestApi.Messages.DataTransferObjects.Products;

namespace BmesRestApi.Messages.Responses.Categories
{
    public class DeleteCategoryResponse : ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}
