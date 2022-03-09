using Microsoft.AspNetCore.Mvc;

namespace PokéMart.API.Services.OrderService;

public interface IOrderService
{
    public Task<Order> PlaceOrder(Order order);
    public ActionResult<Order> GetOrder(Guid orderId);
    public Task UpdateOrder(Order order);
    public Task RemoveOrder(Guid orderId);
}
