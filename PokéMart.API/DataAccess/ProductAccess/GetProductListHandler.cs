using PokéMart.API.Services;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<Product>>
    {
        private readonly IProductService _productService;

        public GetProductListHandler(IProductService productService)
        {
            _productService = productService;
        }
        public Task<IEnumerable<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return _productService.GetAsync();
        }
    }
}
