using Microsoft.AspNetCore.Mvc;
using PokéMart.API.DataAccess.OrderAccess;

namespace PokéMart.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PlaceOrder(Order order)
        {
            var response = await _mediator.Send(new PlaceOrderCommand(order));

            return response != null ? Ok(order) : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetOrder(Guid orderId)
        {
            return await _mediator.Send(new GetOrderQuery(orderId));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateOrder(Order order, Guid orderId)
        {
            order.OrderId = orderId;
            return await _mediator.Send(order);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveOrder(Guid orderId)
        {
            return await _mediator.Send(new RemoveOrderCommand { OrderId = orderId });
        }

    }
}
