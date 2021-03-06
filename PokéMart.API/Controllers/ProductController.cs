using Microsoft.AspNetCore.Mvc;
using PokéMart.API.DataAccess.ProductAccess;
using PokeMart.Contracts.Responses;

namespace PokéMart.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
        {
            var response = await _mediator.Send(new GetProductListQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByIdString(string id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var response = await _mediator.Send(new AddNewProductCommand(product));
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> EditProduct(string id, Product newProduct)
        {
            var response = await _mediator.Send(new UpdateProductCommand(id, newProduct));
            return response == false ? NotFound() : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));
            return response == false ? NotFound() : Ok(response);
        }
    }
}
