using MongoDB.Driver;
using PokéMart.API.Models;

namespace PokéMart.API.DataAccess
{
    public class ProductMongoDB
    {
        public string connectionString { get; set; } = null!;
        public string databaseName { get; set; } = null!;
        public string collectionName { get; set; } = null!;
    }
}
