using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokéMart.API.Models.MongoAccessConfigurations;

namespace PokéMart.API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public readonly IMongoCollection<Order> _orderCollection;
        
        public OrderService(IOptions<OrderMongoDB> orderDbSettings)
        {
            var settings = MongoClientSettings.FromConnectionString(orderDbSettings.Value.connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            var mongoDb = mongoClient.GetDatabase(
                orderDbSettings.Value.databaseName);
            _orderCollection = mongoDb.GetCollection<Order>(
                orderDbSettings.Value.collectionName);
        }
        public async Task<Order> PlaceOrder(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
            return order;
        }

        public async ActionResult<Order> GetOrder(Guid orderId)
        {
            var response = await _orderCollection.FindAsync(x => x.OrderId == orderId);
            if (response == null) NotFoundResult();
        }

        public async Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
