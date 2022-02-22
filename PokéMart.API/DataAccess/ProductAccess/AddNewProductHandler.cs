using PokéMart.API.Services;
using static PokéMart.API.DataAccess.ProductAccess.ProductCommands;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductCommand, string>
    {
        private readonly IProductService _productService;

        public GetProductListHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<string> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.CreateAsync(request.product);
        }
    }
}
