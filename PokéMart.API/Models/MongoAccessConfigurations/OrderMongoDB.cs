namespace PokéMart.API.Models.MongoAccessConfigurations
{
    public class OrderMongoDB
    {
        public string connectionString { get; set; } = null!;
        public string databaseName { get; set; } = null!;
        public string collectionName { get; set; } = null!;
    }
}
