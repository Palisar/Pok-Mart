namespace PokéMart.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product?> GetAsync(string id);
        Task CreateAsync(Product newProduct);
        Task UpdateAsync(string id, Product updateProduct);
        Task RemoveAsync(string id);
    }
}
