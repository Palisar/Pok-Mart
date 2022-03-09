namespace PokéMart.API.Services.ProductService;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAsync();
    Task<Product?> GetAsync(string id);
    Task CreateAsync(Product newProduct);
    Task<bool> UpdateAsync(string id, Product updateProduct);
    Task<bool> RemoveAsync(string id);
}
