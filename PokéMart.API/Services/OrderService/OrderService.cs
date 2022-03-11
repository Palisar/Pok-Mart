using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokéMart.API.Models.MongoAccessConfigurations;

namespace PokéMart.API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;

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

        public async Task<Order> GetOrder(Guid orderId)
        {
            return await _orderCollection.Find(x => x.OrderId == orderId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateOrder(Order order, Guid orderId)
        {
            var response = await _orderCollection.ReplaceOneAsync(x => x.OrderId == orderId, order);
            return response.IsAcknowledged;
        }

        public async Task<bool> RemoveOrder(Guid orderId)
        {
            var response = await _orderCollection.DeleteOneAsync(x => x.OrderId == orderId);
            return response.IsAcknowledged;
        }
    }
}
