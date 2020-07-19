using System.Net;
using BmesRestApi.Messages.Extensions;
using BmesRestApi.Messages.Requests.Products;
using BmesRestApi.Messages.Responses.Products;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly ICatalogService _catalogService;
        private readonly IProductRepository _productRepository;

        public ProductService(ICatalogService catalogService, IProductRepository productRepository)
        {
            _catalogService = catalogService;
            _productRepository = productRepository;
        }

        public CreateProductResponse SaveProduct(CreateProductRequest request)
        {
            var response = new CreateProductResponse();

            WithErrorHandling(() =>
            {
                var product = request.Product.MapToProduct();
                _productRepository.SaveProduct(product);

                var productDto = product.MapToProductDto();
                response.Product = productDto;
                response.Messages.Add("Successfully saved the product");
                response.StatusCode = HttpStatusCode.Created;
            }, response);

            return response;
        }

        public UpdateProductResponse EditProduct(UpdateProductRequest request)
        {
            var response = new UpdateProductResponse();

            WithErrorHandling(() =>
            {
                var product = request.Product.MapToProduct();
                _productRepository.UpdateProduct(product);

                response.Messages.Add("Successfully updated the product");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse();

            WithErrorHandling(() =>
            {
                var product = _productRepository.FindProductById(request.Id);

                var productDto = product.MapToProductDto();
                response.Product = productDto;
                response.Messages.Add("Successfully get the product");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }

        public FetchProductsResponse GetProducts(FetchProductsRequest request)
        {
            var fetchProductsResponse = _catalogService.FetchProducts(request);
            return fetchProductsResponse;
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            var response = new DeleteProductResponse();

            WithErrorHandling(() =>
            {
                var product = _productRepository.FindProductById(request.Id);
                _productRepository.DeleteProduct(product);

                var productDto = product.MapToProductDto();
                response.Product = productDto;
                response.Messages.Add("Successfully deleted the product");
                response.StatusCode = HttpStatusCode.OK;
            }, response);

            return response;
        }
    }
}
