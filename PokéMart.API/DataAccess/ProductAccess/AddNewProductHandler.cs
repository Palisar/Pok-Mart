using PokéMart.API.Services;
using PokéMart.API.DataAccess.ProductAccess;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductCommand, Product>
    {
        private readonly IProductService _productService;

        public AddNewProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Product> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
             await _productService.CreateAsync(request.product);
            return request.product;
        }
    }
}
