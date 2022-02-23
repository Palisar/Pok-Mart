using PokéMart.API.Services;
using PokéMart.API.DataAccess.ProductAccess;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductCommand, string>
    {
        private readonly IProductService _productService;

        public AddNewProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<string> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
             await _productService.CreateAsync(request.product);
            return "";
        }
    }
}
