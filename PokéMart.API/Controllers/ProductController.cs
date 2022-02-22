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
            var products = await _mediator.Send(new GetProductListQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByIdString(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostProduct(Product product)
        {
            var product = _mediator.Send(new AddNewProductCommand(product));
        }
    }
}
