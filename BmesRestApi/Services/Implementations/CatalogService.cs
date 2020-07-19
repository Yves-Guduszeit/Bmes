using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Products;
using BmesRestApi.Messages.Responses.Products;
using BmesRestApi.Models.Products;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class CatalogService : ServiceBase, ICatalogService
    {
        private readonly IProductRepository _productRepository;

        public CatalogService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public FetchProductsResponse FetchProducts(FetchProductsRequest fetchProductsRequest)
        {
            var response = new FetchProductsResponse();

            WithErrorHandling(() =>
            {
                var products = _productRepository.GetAllProducts();

                if (fetchProductsRequest.CategorySlug == "all-categories" && fetchProductsRequest.BrandSlug == "all-brands")
                {
                    products = products
                        .Where(product => product.ProductStatus == ProductStatus.Active);
                }

                if (fetchProductsRequest.CategorySlug != "all-categories" && fetchProductsRequest.BrandSlug != "all-brands")
                {
                    products = products
                        .Where(product => product.ProductStatus == ProductStatus.Active &&
                                          product.Category.Slug == fetchProductsRequest.CategorySlug &&
                                          product.Brand.Slug == fetchProductsRequest.BrandSlug);
                }

                if (fetchProductsRequest.CategorySlug != "all-categories" && fetchProductsRequest.BrandSlug == "all-brands")
                {
                    products = products
                        .Where(product => product.ProductStatus == ProductStatus.Active &&
                                          product.Category.Slug == fetchProductsRequest.CategorySlug);
                }

                if (fetchProductsRequest.CategorySlug == "all-categories" && fetchProductsRequest.BrandSlug != "all-brands")
                {
                    products = products
                        .Where(product => product.ProductStatus == ProductStatus.Active &&
                                          product.Brand.Slug == fetchProductsRequest.BrandSlug);
                }

                products = products
                    .Skip((fetchProductsRequest.PageNumber - 1) * fetchProductsRequest.ProductsPerPage)
                    .Take(fetchProductsRequest.ProductsPerPage)
                    .ToList();

                var productDtos = products.MapToProductDtos();
                var productCount = products.Count();
                var totalPages = (int)Math.Ceiling((decimal)productCount / fetchProductsRequest.ProductsPerPage);
                var pages = Enumerable.Range(1, totalPages).ToArray();

                response.ProductsPerPage = fetchProductsRequest.ProductsPerPage;
                response.Products = productDtos;
                response.HasPreviousPages = fetchProductsRequest.PageNumber > 1;
                response.CurrentPage = fetchProductsRequest.PageNumber;
                response.HasNextPages = fetchProductsRequest.PageNumber < totalPages;
                response.Pages = pages;
                response.Messages.Add("Successfully fetched the products");
                response.StatusCode = HttpStatusCode.OK;
            }, response);


            return response;
        }
    }
}
