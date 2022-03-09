namespace PokéMart.API.Models.MongoAccessConfigurations
{
    public class ProductMongoDB
    {
        public string connectionString { get; set; } = null!;
        public string databaseName { get; set; } = null!;
        public string collectionName { get; set; } = null!;
    }
}
