using PokeMart.Contracts.Responses;
namespace PokeMart.Contracts.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetProductsAsync();
    Task<ProductResponse> PostProductAsync();
}
