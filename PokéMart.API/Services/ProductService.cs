using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PokéMart.API.Services
{
    public class ProductService : IProductService
    {
        public readonly IMongoCollection<Product> _productsCollection;
        public ProductService(IOptions<ProductMongoDB> productDbSettings)
        {
            var settings = MongoClientSettings.FromConnectionString(productDbSettings.Value.connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            var mongoDb = mongoClient.GetDatabase(
                productDbSettings.Value.databaseName);
            _productsCollection = mongoDb.GetCollection<Product>(
                productDbSettings.Value.collectionName);
        }

        public async Task<IEnumerable<Product>> GetAsync() =>
            await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<Product?> GetAsync(string id) =>
            await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product newProduct) =>
            await _productsCollection.InsertOneAsync(newProduct);

        public async Task UpdateAsync(string id, Product updateProduct) =>
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);

        public async Task RemoveAsync(string id) =>
            await _productsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
