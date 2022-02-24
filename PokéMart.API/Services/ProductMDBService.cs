using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace PokéMart.API.Services
{
    public class ProductMDBService : IProductService
    {
        public readonly IMongoCollection<Product> _productsCollection;
        public ProductMDBService(IOptions<ProductMongoDB> productDbSettings)
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

        public async Task<bool> UpdateAsync(string id, Product updateProduct)
        {
            var response = await _productsCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);
            return response.IsAcknowledged;
        }


        public async Task<bool> RemoveAsync(string id)
        {
            var response = await _productsCollection.DeleteOneAsync(x => x.Id == id);
            return response.IsAcknowledged;
        }


    }
}
