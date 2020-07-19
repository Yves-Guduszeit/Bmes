using BmesRestApi.Messages.Requests.Products;
using BmesRestApi.Messages.Responses.Products;

namespace BmesRestApi.Services
{
    public interface ICatalogService
    {
        FetchProductsResponse FetchProducts(FetchProductsRequest fetchProductsRequest);
    }
}
