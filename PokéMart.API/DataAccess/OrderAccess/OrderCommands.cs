using MediatR;

namespace PokéMart.API.DataAccess.OrderAccess;

public record PlaceOrderCommand(Order order) : IRequest<Order>;