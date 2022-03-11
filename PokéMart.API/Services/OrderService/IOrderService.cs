using Microsoft.AspNetCore.Mvc;

namespace PokéMart.API.Services.OrderService;

public interface IOrderService
{
    Task<Order> PlaceOrder(Order order);
    Task<Order> GetOrder(Guid orderId);
    Task<bool> UpdateOrder(Order order, Guid orderId);
    Task<bool> RemoveOrder(Guid orderId);
}
