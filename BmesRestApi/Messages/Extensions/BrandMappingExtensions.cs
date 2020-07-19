using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.DataTransferObjects.Products;
using BmesRestApi.Models.Products;

namespace BmesRestApi.Messages.Extensions
{
    public static class BrandMappingExtensions
    {
        public static Brand MapToBrand(this BrandDto brandDto)
        {
            var brand = new Brand
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Slug = brandDto.Slug,
                Description = brandDto.Description,
                MetaDescription = brandDto.MetaDescription,
                MetaKeywords = brandDto.MetaKeywords,
                BrandStatus = (BrandStatus)brandDto.BrandStatus,
                ModifiedDate = brandDto.ModifiedDate,
                IsDeleted = brandDto.IsDeleted
            };

            return brand;
        }

        public static BrandDto MapToBrandDto(this Brand brand)
        {
            var brandDto = new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                Slug = brand.Slug,
                Description = brand.Description,
                MetaDescription = brand.MetaDescription,
                MetaKeywords = brand.MetaKeywords,
                BrandStatus = (int)brand.BrandStatus,
                ModifiedDate = brand.ModifiedDate,
                IsDeleted = brand.IsDeleted
            };

            return brandDto;
        }

        public static List<BrandDto> MapToBrandDtos(this IEnumerable<Brand> brands)
        {
            var brandDtos = brands.Select(MapToBrandDto).ToList();

            return brandDtos;
        }
    }
}
