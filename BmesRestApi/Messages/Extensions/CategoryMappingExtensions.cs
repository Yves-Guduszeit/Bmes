using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.DataTransferObjects.Products;
using BmesRestApi.Models.Products;

namespace BmesRestApi.Messages.Extensions
{
    public static class CategoryMappingExtensions
    {
        public static Category MapToCategory(this CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Slug = categoryDto.Slug,
                Description = categoryDto.Description,
                MetaDescription = categoryDto.MetaDescription,
                MetaKeywords = categoryDto.MetaKeywords,
                CategoryStatus = (CategoryStatus)categoryDto.CategoryStatus,
                ModifiedDate = categoryDto.ModifiedDate,
                IsDeleted = categoryDto.IsDeleted
            };

            return category;
        }

        public static CategoryDto MapToCategoryDto(this Category category)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                MetaDescription = category.MetaDescription,
                MetaKeywords = category.MetaKeywords,
                CategoryStatus = (int)category.CategoryStatus,
                ModifiedDate = category.ModifiedDate,
                IsDeleted = category.IsDeleted
            };

            return categoryDto;
        }

        public static List<CategoryDto> MapToCategoryDtos(this IEnumerable<Category> categories)
        {
            var categoryDtos = categories.Select(MapToCategoryDto).ToList();

            return categoryDtos;
        }
    }
}
