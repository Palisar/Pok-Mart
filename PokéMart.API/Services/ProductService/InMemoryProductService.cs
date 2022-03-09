namespace PokéMart.API.Services.ProductService
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Product> products = new();
        public InMemoryProductService()
        {
            products.Add(new Product
            {
                Id = "6214cd9ff357c214a3f3e0b6",
                Name = "In Memory Pokeball",
                Description = "This is the test ball",
                Price = 202M,
                ImageUrl = "testball.img"

            });
            products.Add(new Product
            {
                Id = "",
                Name = "In Memory Potion",
                Description = "This is the test potion",
                Price = 302M,
                ImageUrl = "testPotion.jpg"

            });
        }

        public async Task CreateAsync(Product newProduct)
        {
            products.Add(newProduct);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return products;
        }

        public async Task<Product?> GetAsync(string id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var prod = products.FirstOrDefault(x => x.Id == id);
            if (prod != null)
            {
                products.Remove(prod);
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateAsync(string id, Product updateProduct)
        {
            var prod = products.FirstOrDefault(x => x.Id == id);
            if (prod != null)
            {
                prod.Name = updateProduct.Name;
                prod.Description = updateProduct.Description;
                prod.Price = updateProduct.Price;
                prod.ImageUrl = updateProduct.ImageUrl;

                return true;
            }
            return false;
        }
    }
}
