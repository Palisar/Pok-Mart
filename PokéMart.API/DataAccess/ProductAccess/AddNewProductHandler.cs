using PokéMart.API.Services.ProductService;

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
            if (request.product.Price < 0)
            {
                request.product.Price = 0;
            }
            await _productService.CreateAsync(request.product);
            return request.product;
        }
    }
}
