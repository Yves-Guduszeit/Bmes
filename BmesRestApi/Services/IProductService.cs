using BmesRestApi.Messages.Requests.Products;
using BmesRestApi.Messages.Responses.Products;

namespace BmesRestApi.Services
{
    public interface IProductService
    {
        CreateProductResponse SaveProduct(CreateProductRequest request);
        UpdateProductResponse EditProduct(UpdateProductRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        FetchProductsResponse GetProducts(FetchProductsRequest request);
        DeleteProductResponse DeleteProduct(DeleteProductRequest request);
    }
}
