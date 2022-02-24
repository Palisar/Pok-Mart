using PokéMart.API.Services;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            request.product.Id = request.id;
            var response = await _productService.UpdateAsync(request.id, request.product);
            return response;
        }
    }
}
