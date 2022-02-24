using PokéMart.API.Services;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.UpdateAsync(request.id, request.product);
            return request.product;
        }
    }
}
