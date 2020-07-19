using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.DataTransferObjects.Products;
using BmesRestApi.Models.Products;

namespace BmesRestApi.Messages.Extensions
{
    public static class ProductMappingExtensions
    {
        public static Product MapToProduct(this ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Slug = productDto.Slug,
                Description = productDto.Description,
                MetaDescription = productDto.MetaDescription,
                MetaKeywords = productDto.MetaKeywords,
                SKU = productDto.MetaDescription,
                Model = productDto.MetaKeywords,
                Price = productDto.Price,
                SalePrice = productDto.SalePrice,
                OldPrice = productDto.OldPrice,
                ImageUrl = productDto.ImageUrl,
                QuantityInStock = productDto.QuantityInStock,
                IsBestseller = productDto.IsBestseller,
                CategoryId = productDto.CategoryId,
                BrandId = productDto.BrandId,
                ProductStatus = (ProductStatus)productDto.ProductStatus,
                CreatedDate = productDto.CreatedDate,
                ModifiedDate = productDto.ModifiedDate,
                IsDeleted = productDto.IsDeleted
            };

            return product;
        }

        public static ProductDto MapToProductDto(this Product product)
        {
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                Description = product.Description,
                MetaDescription = product.MetaDescription,
                MetaKeywords = product.MetaKeywords,
                SKU = product.MetaDescription,
                Model = product.MetaKeywords,
                Price = product.Price,
                SalePrice = product.SalePrice,
                OldPrice = product.OldPrice,
                ImageUrl = product.ImageUrl,
                QuantityInStock = product.QuantityInStock,
                IsBestseller = product.IsBestseller,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                ProductStatus = (int)product.ProductStatus,
                CreatedDate = product.CreatedDate,
                ModifiedDate = product.ModifiedDate,
                IsDeleted = product.IsDeleted
            };

            return productDto;
        }

        public static List<ProductDto> MapToProductDtos(this IEnumerable<Product> products)
        {
            var productDtos = products.Select(MapToProductDto).ToList();

            return productDtos;
        }
    }
}
