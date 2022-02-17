

using MongoDB.Driver;

namespace PokéMart.API.DataAccess.ProductAccess
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<Product>>
    {
        private readonly IConfiguration _config;

        public GetProductListHandler(IConfiguration config)
        {
            _config = config;
        }
        public Task<IEnumerable<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var client = new MongoClient(_config.GetConnectionString("connectionString"));
        }
    }
}
